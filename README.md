# Containers

**Distribución de artículos desde centros de acopio - Prueba Técnica Mercado Libre**

**El reto** 

Transportes Inc te ha contratado para desarrollar un algoritmo que indique cuáles contenedores se deben seleccionar para su transporte de tal forma que podamos obtener el mayor KPI posible sin exceder el presupuesto establecido.

La firma de tu algoritmo debería ser similar a esta:

        function selectContainers(budget as double, data as Array of Container)
        as Array of String
        // a Container is something like:
        def Container as
        name as String
        transportCost as double
        containerPrice as double
        
El método selectContainers debería devolver los nombres de los contenedores que deben ser transportados.
Ejemplo:

- Se cuenta con un presupuesto de 1508.65 USD para despachar 7 contenedores:

![image](https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/CasoPrueba.JPG)

En este caso, el algoritmo debería indicar que la opción que nos da el mejor KPI es transportar
los contenedores C1, C2 y C4.


# Solución Al Problema
**Nivel 1 y Nivel 2**

- Endpoint Containers es el encargado de retornar los nombres de los contenedores que deben
ser transportados, teniendo en cuenta el presupuesto dado.

https://ch-containers.azurewebsites.net/api/Containers/selectContainers

- Se puede usar la colección de postman adjunta, para realizar su respectiva validación.

https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/ContainersKpi.postman_collection.json

![image](https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/ObtenerContenedoresPOST.JPG)

- Adicional se puede usar la documentación de Swagger para consumir los servicios https://ch-containers.azurewebsites.net/swagger/index.html

![image](https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/Swagger%20ObtenerContenedores.JPG)

**Nivel 3** 

- Endpoint Stats es el encargado de retornar los valores acumulados durante todas las peticiones hechas al servicio deselectContainers.
de los presupuestos, valor contenedores despachados y valor de contenedores no despachados.

https://ch-containers.azurewebsites.net/api/stats/stats

- Se puede usar la colección de postman adjunta, para realizar su respectiva validación.

https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/ContainersKpi.postman_collection.json

![image](https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/ConsultaEstadisticasGET.JPG)

- Adicional se puede usar la documentación de Swagger para consumir los servicios https://ch-containers.azurewebsites.net/swagger/index.html
 
 ![image](https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/Swagger%20ConsultaEstadisticas.JPG)
 
 
 - Para acceder a la información guardada, de los valores de los contenedores despachados y no despachados. es necesario descargar la versión de MongoBD
 para Windows, la cual se encuentra en la siguiente dirección
 
 https://www.mongodb.com/try/download/compass
 
 - Una vez descargado se debe crear una nueva conexión agregando la siguiente cadena de conexión:
 
 mongodb://pruebakpi:IGOkPx3KGIGxlNkirUAcvaILFex2XvqWST8iMJ4il5FpSvBNIAJQ110XR4LNq2Hw6bJHWtAreyVjdseuVQtZ7w==@pruebakpi.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@pruebakpi@
 
![image](https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/MongoConnectionString.JPG)

![image](https://github.com/CristianHiguita0324/Containers/blob/main/Recursos/MongoDocument.JPG)
 
 
 
 # Stack Tecnológico Solución
 
- .NET Core 6.0 (Framework desarrollo)
- MongoBd (Dase de datos)
- Azure (Infraestructura nube para despliegue del servicio y base de datos)
- MSTest (Pruebas Unitarias)
- Fine Code Coverage (Validación Cobertura de código)


- Se usa Arquitectura Limpia para construir la aplicación, con el objetivo de desacoplar los componentes, y que la lógica de negocio no dependa del framework y del motor de la base de datos.
- Se trato de seguir los lineamientos de los principios SOLID y clean code

- La arquitectura de la solución, desde un aspecto general es una arquitectura orientada al dominio, es decir, que se comporta de acuerdo a las funcionalidades requeridas por el negocio.
De manera transversal y de uso compartido por todos los componentes del código fuente, se encuentran entidades, funciones compartidas y constantes, los cuales son únicos en toda la aplicación, generando un minino de duplicidad de código.
Con respecto a los componentes de servicios se cuenta con controladores independientes para exponer la información requerida, comunicándose con la capa de aplicación, que básicamente cumple la función de enrutar las peticiones hacia el dominio que le corresponde según la funcionalidad solicitada consumidor, esta capa de dominio contiene la lógica de la aplicación, las reglas de negocio, las validaciones y cálculos específicos de cada comportamiento y también se encarga de llevar los datos hacia la capa de persistencia que registra los datos en la base de datos usando conectores específicos, un patrón de diseño llamado Repository y complementado con el patron Factory que simplifica la administración de los datos y mejora el rendimiento del proceso de transporte de datos.


# Configuración y Ejecución 

- Se debe clonar el repositorio con el siguiente comando de Git 

git clone https://github.com/CristianHiguita0324/Containers.git

- Desde visual Studio 2022 se debe abrir el proyecto
- Se debe establecer el proyecto **Ch.Kpi.Containers.Api** como proyecto de inicio
- Iniciar la ejecución.
- Se abrirá un navegador "localHost" con la especificación Swagger, desde donde se podrá realizar la validación correspondiente o si lo desea desde la colección de postman se puede ejecutar, solo debe cambiar el host.

**Ejecución de las pruebas**

- vamos al menú  **Extensions** en la barra superior de visual Studio
- Buscamos Fine Code Coverage y lo instalamos.
- Sera necesario reiniciar el Visual estudio
- vamos a la opción **Test/Run all test** en la barra superior de visual studio 


 ![image](https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/UnitTest.JPG)
 
 
 ![image](https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/Summary%20UnitTest.JPG)
 
 
