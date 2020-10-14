using Npgsql;
using Npgsql.NameTranslation;

namespace DatabaseCSharp
{
	public static class EnumFixer
	{
		private static readonly NpgsqlSnakeCaseNameTranslator translator = new NpgsqlSnakeCaseNameTranslator();

		/// <summary>
		/// DO NOT USE! For database model initialization only. Intended to be used only in database context static constructor
		/// </summary>
		internal static void MapEnums()
		{
			NpgsqlConnection.GlobalTypeMapper.MapEnum<ProductType>("product_type", translator);
			NpgsqlConnection.GlobalTypeMapper.MapEnum<SpecsTable>("specs_table", new NpgsqlNullNameTranslator());
			NpgsqlConnection.GlobalTypeMapper.MapEnum<OrderStatus>("order_status", translator);
			NpgsqlConnection.GlobalTypeMapper.MapEnum<OSDesktop>("os_desktop", translator);
			NpgsqlConnection.GlobalTypeMapper.MapEnum<OSMobile>("os_mobile", translator);
		}
	}
}