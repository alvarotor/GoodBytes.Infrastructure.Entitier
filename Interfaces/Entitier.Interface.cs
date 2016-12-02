using GoodBytes.DAL;
using GoodBytes.DAL.Base.Interfaces;
using System.Collections.Generic;

namespace GoodBytes.Infrastructure.Entitier.Interfaces
{
	public interface IEntitierInterface : IConnectionBaseInterface, IBaseInterface
	{
		bool RowsFounded { get; }

		void ParameterAdd(string text, object value, SqlVariables var, SqlDirections directions = SqlDirections.Input);

		void Execute(string storeProcedure, bool transaccion = false, bool returnId = false, bool RowsNotAffectedError = true);

		List<T> GetList<T>(string storeProcedure) where T : new();

		T Get<T>(string storeProcedure) where T : new();

		object Scalar(string storeProcedure);

		T PassToClass<T>(object type) where T : new();
	}
}