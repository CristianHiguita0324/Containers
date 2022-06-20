# Containers

Distribución de artículos desde centros de acopio - Prueba Tecnica Mercado Libre

El reto
Transporters Inc te ha contratado para desarrollar un algoritmo que indique cuáles contenedores se deben seleccionar para su transporte de tal forma que podamos obtener el mayor KPI posible sin exceder el presupuesto establecido.

La firma de tu algoritmo debería ser similar a esta:

        function selectContainers( budget as double, data as Array of Container)
        as Array of String
        // a Container is something like:
        def Container as
        name as String
        transportCost as double
        containerPrice as double
        
El método selectContainers debería devolver los nombres de los contenedores que deben ser transportados.
Ejemplo:

Se cuenta con un presupuesto de 1508.65 USD para despachar 7 contenedores:

//Imagen caso

En este caso, el algoritmo debería indicar que la opción que nos da el mejor KPI es transportar
los contenedores C1, C2 y C4.


Solución Al Problema
Nivel 1 y Nivel 2

Endpoint Containers es el encargado de retornar los nombres de los contenedores que deben
ser transportados, teniendo en cuenta el presupuesto dado.

https://ch-containers.azurewebsites.net/api/Containers/selectContainers

-Se puede usar la coleccion de postman adjunta, para realizar su respectiva validacion.
//Imagen Postman

-Adicional se puede usar la documentaciòn de Swagger para consumir los servicios https://ch-containers.azurewebsites.net/swagger/index.html
Imagen Swagger


Nivel 3 

Endpoint Stats es el encargado de retornar los valores acumulados durante todas las peticiones hechas al servicio deselectContainers.
de los presupuestos, valor contenedores despachados y valor de contenedores no despachados.

https://ch-containers.azurewebsites.net/api/stats/stats

-Se puede usar la coleccion de postman adjunta, para realizar su respectiva validacion.

https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/ConsultaEstadisticasGET.JPG


-Adicional se puede usar la documentaciòn de Swagger para consumir los servicios https://ch-containers.azurewebsites.net/swagger/index.html

https://github.com/CristianHiguita0324/Containers/blob/develop/Recursos/Swagger%20ConsultaEstadisticas.JPG












