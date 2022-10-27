# Delegados, EventosTarea

## Crear una escena simple en Unity, con dos objetos: Notificador y Suscriptor y prueba el código en las transparencias.

Primero debemos crear un objeto que sirva como `Notificador`, se tendra como propiedad un evento que se ejecutará cada segundo. Segundo se necesita de un `Suscriptor`, el añadirá una función ha llamar cuando se ejecute el evento del `Notificador`. De esta manera, podemos cambiar el color de `Suscriptor` cada segundo.

![](/observer-1.gif)

## Crear una escena en Unity, con objetos de tipo A, B y un único objeto C con los siguientes comportamientos:

### Cuando el jugador colisiona con un objeto de tipo B, los objetos A se acercan al objeto C. Cuando toca algún objeto A se incrementa el tamaño de cualquier objeto B

Para poder realizar esto deberemos crear un script `PlayerCollision`, el cual tiene un evento `OnCollision` que acepta la tag del objeto con el que chocó y cuando este un jugador colisiona con un objeto que tenga este script se llamará al evento `OnCollision`. Hay que destacar que el evento tiene que ser `static` para que pueda funcionar con varios objetos a la vez.

Luego tendremos que agregar a los `objetos de tipo A` que esten escuchando el evento `OnCollision` y que cuando el tag que trae se `ObjectB` deberá añadirle una fuerza hacia el `objeto C` más cercano.

![](/objects-1.gif)

Y para los `objetos B` deberemos escuchar igualemente el evento y cuando la tag sea `ObjectA` deberá se aumentará el tamaño con un factor de crecimiento.

![](/objects-2.gif)

### Cuando el jugador se aproxima al objeto de tipo C, los objetos de tipo A cambian su color y saltan y los objetos de tipo B se orientan hacia un objetivo ubicado en la escena con ese propósito

Para poder simular que el jugador se acerca a un objeto podemos añadirle un objeto vacio a este, al que le agregaremos un `Sphere Collider` con el radios de detección y de tipo `Is Trigger`; y un script con un evento llamado `OnRange`, también `static`, el cual cuando un jugador produzca `OnTriggerEnter` entonces llamará al evento con la tag del padre del objeto vacio.

Ahora haremos que los `objetos A` escuchen el evento `OnRange` y que cuando la tag sea `ObjectC` se les agrege a estos una fuerza de subida y además se les cambie el color del material a uno al azar.

![](/objects-3.gif)

Por último, los `objetos B` también deberas escuchar a `OnRange` y cuando la tag sea `ObjectC` primero se pasará el objeto a `IsKinematic`, para que asi no pueda moverse y se usará `LookAt` para que los `objetos B` miren hacia la esfera del centro. Tras esperar 1 segundo, se desactiva `IsKinematic` para que así el objeto deje de mirar la esfera.

![](/objects-4.gif)

### Buscar información de Debug.DrawRay y utilízala para depuración

Con `Debug.DrawRay` se podrá crear una linea en la dirección y punto de origen que queramos, por lo que para ver si los `objetos B` en verdad miran hacia la esfera dibujaremos una línea desde la posición del objeto y en dirección hacia delante de este durante el segundo en que esta mirando.

![](/objects-5.gif)
