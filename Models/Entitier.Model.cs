using GoodBytes.DAL;

namespace GoodBytes.Infrastructure.Entitier.Models
{
	public class ArgumentsModel
	{
		public string Text { get; set; }
		public object Value { get; set; }
		public SqlVariables Var { get; set; }
		public SqlDirections Directions { get; set; }
	}
}