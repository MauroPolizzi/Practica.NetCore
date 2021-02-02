namespace PP.Aplicacion.ConectionString
{
    public static class ConetionString
    {
        #region Conexion de Mauro
        const string Servidor = @"LAPTOP-31N6BQDF\SQLEXPRESS";
        const string BaseDatos = "PracticaNetCore";
        #endregion


        public static string GetWithWindows => $"Data Source={Servidor}; " +
                                               $"Initial Catalog={BaseDatos}; " +
                                               $"Integrated Security=True;";
    }
}
