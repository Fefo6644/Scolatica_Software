# Scolatica: Programa PC


Desarrollado en C# con el [IDE Visual Studio](https://visualstudio.microsoft.com/).
El IDE les ahorrará __muchísimo__ tiempo en el desarrollo y diseño del programa (por eso fue elegido, por su simplicidad y capacidad gráfica y por su relativamente _fácil e intuitivo_ manejo).


Corre bajo el .NET Framework 4.0 (el cual se necesitará para la compilación del programa) (versiones posteriores no funcionan en Windows XP).


Otra documentación requerida (como objetos y funciones utilizadas) se puede encontrar [acá](https://docs.microsoft.com/es-ar/dotnet/api/?view=netframework-4.0).




## __build__ y __clean__


Cada uno de esos archivos sirve para compilar (en la carpeta bin/Release) el aplicativo o borrar los archivos de compilación.




## DatosProfesores.xml


Ahí es donde se encuentra la 'base de datos', se basa en elementos, atributos y valores. Se explica la estructura básica del lenguaje [acá](https://es.wikipedia.org/wiki/Extensible_Markup_Language#Estructura_de_un_documento_XML) (el atributo 'codigo' es donde va el ID del PICC asociado al docente).
Se decidió reemplazar los días (Lunes, Martes, etc.) con _1, _2, etc. por temas de idioma de la computadora (el programa puede devolver 'Lunes' o 'Monday', si lo expresamos en número, es universal).

__NOTA: El XML debe estar en la misma ubicación/carpeta que el ejecutable!!__
__NOTA: El XML debe estar en la misma ubicación/carpeta que el ejecutable!!__
__NOTA: El XML debe estar en la misma ubicación/carpeta que el ejecutable!!__




## Modos del programa


El programa tiene dos modos de funcionamiento, el modo normal y el modo de depuración.



### Modo normal


Se abre el ejecutable normalmente.


### Modo de depuración


Desde la consola de Windows (en el directorio del ejecutable) se escribe 'Scolatica.exe -DEBUG' (sin las comillas simples) y en vez de visualizarse la lista de laboratorios, se muestra una caja de texto, funciona igual que el monitor serial del IDE de Arduino, pero sin tener que esperar a que cargue el IDE de Arduino (que tarda su tiempo).




## Contacto


Si tienen problemas o dudas con el desarrollo del programa, mandar e-mail a [scolatica.chaparral@gmail.com](mailto:scolatica.chaparral@gmail.com).
