# Operación Fuego de Quasar
Este proyecto se desarrolla con el fin de solucionar el reto técnico para ser parte del equipo de tecnología en **Mercado Libre**.

El objetivo principal es desarrollar una aplicación de servicios web REST Full que permita ubicar una nave espacial utilización la técnica de la **trilateración** a partir de 3 satélites de referencia. Mas información: [operación Fuego de Quasar](Documentation\Operacion-Fuego-de-Quasar.pdf)

## **Información General**
### Herramientas de desarrollo
* [ASP.NET](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [XUnit](https://xunit.net/)
* [Swagger](https://swagger.io/)
* [Dapper Micro ORM](https://dapper-tutorial.net/)
### Herramientas de infraestructura
* [Azure App Service](https://azure.microsoft.com/es-es/services/app-service/)
* [Azure SQL Database](https://azure.microsoft.com/es-es/services/sql-database/)
### Herramientas de administración de proyecto
* [Azure DevOps](https://azure.microsoft.com/es-es/services/devops/)
* [Azure Pipelines](https://azure.microsoft.com/es-es/services/devops/pipelines/)

## **Ejecución Local**
* Se requiere el IDE [Visual Studio](https://visualstudio.microsoft.com/es/)
* **Configuración de la base de datos**
  * En el proyecto **MercadoLibre.OperacionQasar.DataBase** debe publicarse (Click Derecho, Publish..)
  ![Project-DataBase-Publish](https://user-images.githubusercontent.com/35159383/108167304-7cd1f400-70c3-11eb-84e8-e19874bf3104.png)
  * Seleccionar la conexión:
  ![Project-DataBase-Publish-Connections](https://user-images.githubusercontent.com/35159383/108167305-7d6a8a80-70c3-11eb-8de2-a139bfe90030.png)
  * Debe conectarse a la base de datos creada y ejecutar el **Procedimiento Almacenado** **[dbo.StartApplication]**
  * En el proyecto **MercadoLibre.OperacionQasar.WebApp** en el archivo **appsettings.Development.json** debe especificar la cadena de conexion a la base de datos creada en la propiedad **ConnectionStrings.DefaultConnection**
* **Ejecución de la aplicación Web**
  * En **Visual Studio** se debe seleccionar el proyecto **MercadoLibre.OperacionQasar.WebApp** por defecto para ejecutar. Se recomienda seleccionar el servidor web **IIS Express**
  ![Project-WebApp-Execution](https://user-images.githubusercontent.com/35159383/108167308-7d6a8a80-70c3-11eb-9c23-a7b34779e868.png)
* **Ejecución de pruebas Unitarias**
  * En la vista del **Explorador de Pruebas**  se ejecutan todas las pruebas
  ![Project-Test-Execution](https://user-images.githubusercontent.com/35159383/108167306-7d6a8a80-70c3-11eb-83c7-13fcbdb1632c.png)

## **Arquitectura de Software**
Prácticas de desarrollo implementadas:
* [SOLID](https://es.wikipedia.org/wiki/SOLID)
* [Patrón Diseño guiado por el dominio (DDD)](https://es.wikipedia.org/wiki/Dise%C3%B1o_guiado_por_el_dominio)
* [Patrón Repository](https://our-academy.org/posts/el-patron-repository:-implementacion-y-buenas-practicas)
* [Patrón de inyección de dependencias](https://es.wikipedia.org/wiki/Inyecci%C3%B3n_de_dependencias)
* [Unit Testing](https://es.wikipedia.org/wiki/Prueba_unitaria)
### **Diagrama de Paquetes**
Se implementa la arquitectura MVC segregado por las siguientes capas

![PackagesDiagram](https://user-images.githubusercontent.com/35159383/108167277-72aff580-70c3-11eb-96f9-04bf804ace89.jpg)

**MercadoLibre.OperacionQasar.Core**
* **Repository** 
  * Uso de Dapper como micro ORM para obtener datos de SQL Server 
  * Capa encargada del acceso a Datos (SQL Server, MemoryCache)
  * implementación del patrón repositorio
* **Domain (Service)**
  * Implementa la lógica de negocio segregado por Dominios (servicios)
* **Utils**
	* Exponer clases con funciones útiles en cualquier parte del sistema
 
**MercadoLibre.OperacionQasar.WebApp**
* **Controller**
  *  Capa encargada de recibir todas las solicitudes **HTTP**
* **Authentication Filter**
  * Define Los filtros de autenticación para identificar el usuario el cual requiere de algún End-Point

**MercadoLibre.OperacionQasar.Test**
* **Unit**
  * Contenedor de las pruebas unitarias del sistema

## **Administración del proyecto**
Se implementa [Azure DevOps](https://azure.microsoft.com/es-es/services/devops/) para administrar el proyecto

![Azure-DevOps](https://user-images.githubusercontent.com/35159383/108167314-7e032100-70c3-11eb-9bd6-347b36e4cc73.png)

### **configuración**
* Service Connections
  * Conexión con el repositorio privado en **GitHub**
  * Conexión con la suscripción de **Azure**

![Azure-DevOps-Settings](https://user-images.githubusercontent.com/35159383/108167303-7cd1f400-70c3-11eb-94ff-47e7922172c8.png)

## **Infraestructura y despliegue**
El proyecto se despliega utilizando diferentes servicios del portal de **Azure**
Se requiere tener una suscripción activa en el portal de **Azure**

### **Diagrama de despliegue**
![DeploymentDiagram](https://user-images.githubusercontent.com/35159383/108166832-c0782e00-70c2-11eb-836d-12b14c147ae3.jpg)

* **Azure Server**
  Servidores de azure que provee el uso de los siguientes servicios:
  * **Resource Group:**
  Administra todos los recursos y servicios de infraestructura de nuestra aplicación
    * **Web App Service:**
    Servicio que permite el despliegue del API service
    * **Azure SQL Data Base Server**
    Servidor que aloja la base de datos usada por el API Service

  * **Azure DevOps Organization:**
  Plataforma que nos permite la administración del proyecto
    * **Operacion Qasar Project**
    Instancia que almacena toda la información del proyecto
      * **Azure Pipeline:**
      Servicio que permite la definición del Job para el despliegue de la aplicación. Se definen las tareas necesarias para realizar el despliegue de todos los componentes:
      ![Azure-DevOps-Pipeline](https://user-images.githubusercontent.com/35159383/108167300-7c395d80-70c3-11eb-8a05-91daf2225ecb.png)
      
      Éste se ejecuta de manera manual o después de que un **Pull Request** es aprobado en **GitHub:**
      ![Azure-DevOps-Pipeline-Trigger](https://user-images.githubusercontent.com/35159383/108167302-7cd1f400-70c3-11eb-8f3b-c0622e670907.png)

## **Características de la aplicación**
* Implementa **Swagger** el cual nos ofrece una interfaz grafica que permite el uso de los diferentes servicios directamente desde el **Navegador Web** https://operacion-fuego-qasar.azurewebsites.net/swagger/index.html
![Swagger-UI](https://user-images.githubusercontent.com/35159383/108167312-7e032100-70c3-11eb-9d19-380295baef6e.png)
* **Autenticación**
  * Como aplicación productiva se requiere el uso de autenticación de usuarios, en este caso se implementa la autenticación _Basic_ el cual requiere de usuario y contraseña: 
    * Usuario: meli.admin@meli.com
    * Contraseña: Meli.2021
    * Credenciales codificadas en Base 64: bWVsaS5hZG1pbkBtZWxpLmNvbTpNZWxpLjIwMjE=
  * Utilizando la interfaz grafica de **Swagger** podemos realizar la autenticación (Botón 'Authorize'):
![Swagger-Authentication](https://user-images.githubusercontent.com/35159383/108167310-7e032100-70c3-11eb-9e44-a422bd51f35f.png)

* **Servicios**
  * POST
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret
      * Recibe las distancias y mensajes emitidos por la nave.
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado. 
      
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/{satellite_name}
      * Recibe la distancia y el mensaje a un solo satélite. Internamente es almacenado en la **Memoria Cache**
      * Retorna **true** si la información del satélite fue almacenada exitosamente
  * GET
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado siempre y cuando toda la información requerida allá sido previamente enviada al servidor
    * https://operacion-fuego-qasar.azurewebsites.net/api/v1/satellite/topsecret_split/{satellite_name}
      * Retorna la ubicación exacta de la nave junto con el mensaje descifrado siempre y cuando toda la información requerida allá sido previamente enviada al servidor

