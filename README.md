# Prueba Tecnica Oscar Alfaro | Instrucciones de ejecución
- Descargar repositorio en su computadora (Si es en .zip descomprimir antes de iniciar).
- Ejecutar consultas de archivo PruebaTecnicaDB.sql
- Abrir o ejecutar solución de proyecto (OscarAlfaroPruebaTecnica.sln).
- Si no estan instaladas las dependencias EntityFramework, ir a Herramientas > Administrador de Paquetes NuGet > Examinar, descargar las siguientes herramientas:
    * Microsoft.EntityFrameworkCore.SqlServer Versión 5.0.17
    * Microsoft.EntityFrameworkCore.Tools Versión 5.0.17
    * Microsoft.VisualStudio.Web.CodeGeneration.Design Versión 5.0.2
    * Rotativa.AspNetCore Versión 1.2.0 - beta (Seleccionar 'Incluir versión preliminar para seleccionar la versión beta')
- Iniciar conexión con base de datos y crear contexto para el enlace, ir a Herramientas > Administrador de Paquetes Nuget > Consola de administración de paquetes. Insertar   siguiente comando:
    * Scaffold-DbContext "Server=<SUSERVIDORLOCAL>; database=PTDB; integrated security=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -             OutputDir Models
- Abrir archivo appsettings.json y modificar el enlace de conexión:
    * "conection": "Server=<SUSERVIDORLOCAL>; database=PTDB; integrated security=True; TrustServerCertificate=True;"
- Una vez hecho estas configuraciones, ejecutar el programa.
