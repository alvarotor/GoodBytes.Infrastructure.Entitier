using GoodBytes.DAL;
using GoodBytes.DAL.Base.Services;
using GoodBytes.Infrastructure.Entitier.Interfaces;
using GoodBytes.Infrastructure.Entitier.Models;
using GoodBytes.Infrastructure.Entitier.Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace GoodBytes.Infrastructure.Entitier.Services
{
	public class EntitierService : BaseService, IEntitierInterface
	{
		private readonly IDALInterface _data;
		private List<ArgumentsModel> _parameters;

		public bool RowsFounded { get; private set; }

		#region Constructor Code

		private bool _disposed;

		public EntitierService(IDALInterface data)
		{
			_data = data;
			RowsFounded = false;
		}

		~EntitierService()
		{
			Dispose();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_data.Dispose();
				}
			}
			_disposed = true;
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		#region Connection

		public void TransactionFinish(bool value = true)
		{
			_data.TransactionFinish(value);
		}

		public object Transaction
		{
			get { return _data.Transaction; }
			set { _data.Transaction = (SqlTransaction)value; }
		}

		public object Connection
		{
			get { return _data.Connection; }
			set { _data.Connection = (SqlConnection)value; }
		}

		public void Connect()
		{
			_data.Connect();
		}

		public void Disconnect()
		{
			_data.Disconnect();
		}

		#endregion

		public void ParameterAdd(string text, object value, SqlVariables var, SqlDirections direction = SqlDirections.Input)
		{
			if (string.IsNullOrEmpty(text))
				throw new ArgumentNullException(EntitierStrings.MustProvideName);
			var model = new ArgumentsModel { Text = text, Value = value, Var = var, Directions = direction };
			if (_parameters == null) _parameters = new List<ArgumentsModel>();
			_parameters.Add(model);
		}

		public void Execute(string storeProcedure, bool transaccion = false, bool returnId = false, bool RowsNotAffectedError = true)
		{
			if (string.IsNullOrEmpty(storeProcedure))
				throw new ArgumentNullException(EntitierStrings.MustProvideSP);
			LoadParameters();
			_data.IDReturnName = IDReturnName;
			if (transaccion)
				_data.ExecuteWithTransaction(storeProcedure);
			else
				_data.Execute(storeProcedure, false);
			_data.IDReturnName = string.Empty;
#warning CantDeleteDataReferencedInTables
			if (_data.ReturnValue == "547")
				throw new Exception(EntitierStrings.CantDeleteDataReferencedInTables);
			if (_data.RowsAffected <= 0 && RowsNotAffectedError)
				throw new Exception(EntitierStrings.RowsNotAffected);
			if (returnId && Convert.ToInt64(_data.ID) > 0)
				ID = Convert.ToInt64(_data.ID);
		}

		private void LoadParameters()
		{
			if (_parameters != null)
			{
				if (_parameters.Count > 0)
					foreach (ArgumentsModel item in _parameters)
						_data.AddParameter(item.Text, item.Value, item.Var, item.Directions);
				_parameters.Clear();
			}
		}

		public T Get<T>(string storeProcedure) where T : new()
		{
			if (string.IsNullOrEmpty(storeProcedure))
				throw new ArgumentNullException(EntitierStrings.MustProvideSP);
			var model = new T();
			LoadParameters();
			Dictionary<string, object> columns = DictionaryFromType(new T());
			model = ColumnsFill<T>(_data.Read(storeProcedure, columns));
			RowsFounded = model != null;
			return model;
		}

		public List<T> GetList<T>(string storeProcedure) where T : new()
		{
			if (string.IsNullOrEmpty(storeProcedure))
				throw new ArgumentNullException(EntitierStrings.MustProvideSP);
			var model = new List<T>();
			LoadParameters();
			Dictionary<string, object> columns = DictionaryFromType(new T());
			foreach (var item in _data.ReadList(storeProcedure, columns))
				model.Add(ColumnsFill<T>(item));
			RowsFounded = model.Count > 0;
			return model;
		}

		private Dictionary<string, object> DictionaryFromType(object atype)
		{
			if (atype == null) return new Dictionary<string, object>();
			Type t = atype.GetType();
			PropertyInfo[] props = t.GetProperties();
			var dict = new Dictionary<string, object>();
			foreach (PropertyInfo prp in props)
			{
				object value = prp.GetValue(atype, new object[] { });
				dict.Add(prp.Name, value);
			}
			return dict;
		}

		private T ColumnsFill<T>(Dictionary<string, object> columns) where T : new()
		{
			var model = new T();
			foreach (var item in columns)
			{
				PropertyInfo prop = model.GetType().GetProperty(item.Key, BindingFlags.Public | BindingFlags.Instance);
				if (null == prop || !prop.CanWrite) continue;
				if (item.Value == null || string.IsNullOrEmpty(item.Value.ToString()))
					prop.SetValue(model, null);
				else
				{
					Type t = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

					object safeValue;
					if (t.IsEnum)
						safeValue = Enum.Parse(t, item.Value.ToString());
					else
						safeValue = (item.Value == null) ? null : Convert.ChangeType(item.Value, t);

					prop.SetValue(model, safeValue, null);
					//var value = Convert.ChangeType(item.Value, prop.PropertyType);
					//prop.SetValue(model, value.ToString() != string.Empty ? value : null, null);
				}
			}
			return model;
		}

		public object Scalar(string storeProcedure)
		{
			if (string.IsNullOrEmpty(storeProcedure))
				throw new ArgumentNullException(EntitierStrings.MustProvideSP);
			LoadParameters();
			_data.Execute(storeProcedure, true);
			object result = _data.ScalarValue;
			if (Convert.IsDBNull(result))
				return null;
			return result;
		}

		public T PassToClass<T>(object type) where T : new()
		{
			return ColumnsFill<T>(DictionaryFromType(type));
		}
	}
}