# Factory.IO

##### Una serie de menues, funcionales para mantener un registro de lo producido en la empresa.
<p>
____________________________________________________________________________________________________________________________
</p>
<p>
Este proyecto consiste en un serie de menues, en donde el usuario (Supervisor u Operario) interactua con el sistema, registrando modificaciones en el stock de materias primas de la empresa y producción de productos finales .
</p>

<ul>
<li>Ingresar al sistema completando los datos requeridos en el menu **Login**
<li>En el menu usuario tendra varias opciones a seguir, pero lo mas distintivo, sera el stock actual de materia prima y los productos finales con sus valores mostrados allí mismo, constantemente actulizados ante alguna modificación
<li>Tiene la opcion de ingresar a los sectores de produccion, en donde tanto Supervisor como Operario podran trabajar en los diferentes sectores de trabajo
<li>Tiene tambien varias opciones con las cuales podria interactuar si es Supervisor
</ul>

<p>
____________________________________________________________________________________________________________________________
</p>

## Ingreso del Usuario

En el formulario usted tendra casillas en donde ingresara sus datos personales, id de la empresa, dni, cargo y contraseña con la cual le permitira el ingreso al Menu de Usuarios.
En caso de no estar registrado en la base de datos, debera regsitrarse ingresando a su formulario con el boton "registrar".

[![lobby.png](https://i.postimg.cc/ZY8dCv0Q/lobby.png)](https://postimg.cc/kD54H4QN)

## Menu de Usuario

Aqui podremos visualizar los tipos y cantidades de materia prima que hay. Tambien habrá botones con los cuales podremos interactuar, como los sectores de trabajo, en donde aparece a su costado las cantidades producidas hasta el momento de cada una de ellas. Para ambos Usuarios, podrán ver sus datos personales en la opcion "datos del usuario".
En el caso de que haya ingresado un Supervisor, tendrá también la opciones de ingresar a un formulario en donde podrá interactuar con el Stock de las materias primas. Ademas, podria ver una lista de los operarios registrados hasta el momento.

[![principal.png](https://i.postimg.cc/zXJMbWD2/principal.png)](https://postimg.cc/PNRK0Cw1)

## Producción materiales

A un costado del a formulario se encontrarán las cantidades y tipos de materias primas a utlizar, con sus cantidades actuales. Se puede visualizar cuantos materiales se utilizaran con la fabricación de 'x' producto, debería interactuar con el boton que dice 'Materiales necesarios'. 
Podra fabricar cualquier cantidad ingresada, tiene un límite de 1500 como máximo, en caso de no tener las cantidades necesarias para fabricar dicho producto, el Usuario sera comunicado y se mostrara las cantidades faltantes para fabricar la cantidad de productos ingresada. 
El símbolo (?) es para que el programa le de información al Usuario de como manejarse y explica un poco el menu mismo, asi será mas facil de orientar al Usuario.

[![producto-final.png](https://i.postimg.cc/52GbSp62/producto-final.png)](https://postimg.cc/18pk9GGk)

## Stock

En el formulario mostrará las cantidades de materiales que hay en ese momento, junto a su tipo de material. Para poder agregar materiales al Stock, debera ingresar ID, tipo de material y cantidad, terminando con la interacción del boton "Load" que cargará de ser posible la cantidad ingresada.

[![stock.png](https://i.postimg.cc/pXsFRN1c/stock.png)](https://postimg.cc/3dDRFqh2)

<p>
____________________________________________________________________________________________________________________________
</p>

## Listado de Operarios

En este formulario se encontrara un registro de todos los operarios que se encuentran en la empresa, solo los supervisores tienen acceso a este formulario.
Este podrá registrar, modificar o eliminar un Operario de la base de datos.

[![dtgv.png](https://i.postimg.cc/y8533mKF/dtgv.png)](https://postimg.cc/Mn7phjvT)

<p>
____________________________________________________________________________________________________________________________
</p>

## Registro Usuario

Aquí se podrá registrar al Usuario, Operario u Supervisor, parmitiendo agregar al Usuario creado a la base de datos.

[![registro.png](https://i.postimg.cc/4N0xWX0G/registro.png)](https://postimg.cc/vcWyBwM2)

<p>
____________________________________________________________________________________________________________________________
</p>

## Modificación Usuario

Aquí se podrá modificar los datos de un Operario, ingresando su ID, se cargaran los datos del Usuario y de ser posible se podrán modificar los datos que desee.

[![Modificar.png](https://i.postimg.cc/9f5FjJVN/Modificar.png)](https://postimg.cc/Sndp6LnW)

<p>
____________________________________________________________________________________________________________________________
</p>

## Eliminar Usuario

Aquí se podrá dar de baja a un Operario, ingresando su ID, si existe en la base de datos se dará de baja mostrando un mensaje de éxito si pue posible.

[![Eliminar.png](https://i.postimg.cc/9fhVk0t6/Eliminar.png)](https://postimg.cc/qNj9hkFw)

<p>
____________________________________________________________________________________________________________________________
</p>

##### Cómo modificar este proyecto para su propio negocio

Dado que este es un proyecto de ejemplo, te recomiendo que clones y cambies el nombre de este proyecto para usarlo en tus propósitos. Es un buen texto inicial.

<p>
____________________________________________________________________________________________________________________________
</p>

##### Encontro un Error?

Si encontró un problema o desea enviar una mejora a este proyecto, envíe una idea para mejorar o arreglar ese problema.

Archivo PDF donde se encuentra los mismo que en el README:
[Factory.pdf](https://github.com/MarcosCrRodriguez/laboratorio_2_Parcial/files/13427681/Factory.pdf)


