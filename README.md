# Minijuego Fall Guys desarrollado en Unity

## Descripción
Este proyecto es un minijuego en tercera persona desarrollado en Unity, inspirado en el famoso juego de plataformas Fall Guys. Utiliza assets que recuerdan al estilo de Fall Guys y está programado en C#. El objetivo del juego es guiar al personaje desde la salida hasta la meta, contando con un total de 3 vidas.

## Características del Juego
- **Nivel Único**: El juego cuenta con un nivel extenso, diseñado para ofrecer una experiencia completa similar a la de un juego real.
- **Desafíos Dinámicos**: Incluye aspas giratorias que cambian de dirección aleatoriamente, zepelines que se mueven a través del escenario, y plataformas giratorias que operan en sentido contrario a las aspas.
- **Sistema de Vidas**: El jugador tiene tres vidas, y perderá una si es golpeado por una aspa, cae fuera del escenario, o falla en superar un obstáculo.
- **Gestión de Escena**: Organización adecuada de los componentes de la escena y aplicación correcta de materiales.
- **Sonidos**: Incorpora efectos de sonido ambientales y para colisiones y animaciones.

## Cómo Jugar
1. **Inicio del Juego**: Al iniciar el juego, el jugador verá una pantalla de inicio antes de comenzar la partida.
2. **Controles**: Usa las teclas de dirección o WASD para mover al personaje. Espacio para saltar.
3. **Meta del Juego**: Lleva al personaje desde el punto de inicio hasta la meta sin perder las tres vidas.

## Implementación Técnica
- **Coroutines en Unity**: Utilizadas para manejar la lógica de cambio en el comportamiento de las aspas y la instanciación de zepelines.
- **Canvas UI**: Muestra las vidas restantes y el tiempo disponible para completar el nivel.
- **Cámara en Tercera Persona**: Sigue al personaje sin moverse en el eje vertical al saltar.

## Instalación
Para jugar o modificar este juego, necesitarás:
1. Clonar el repositorio a tu máquina local:
[git clone https://github.com/dblancou/MinijuegoFallGuysUnity.git]
2. Abrir el proyecto con Unity.
3. Asegúrate de que todas las dependencias necesarias están instaladas.

## Contribuir
Si deseas contribuir al proyecto, por favor sigue las siguientes instrucciones:
1. Fork el repositorio.
2. Crea una nueva rama para tus cambios.
3. Haz tus cambios y pruebas.
4. Envía un pull request con una descripción detallada de tus modificaciones.

## Créditos
Desarrollado por Daniel Blanco. Inspirado en el juego Fall Guys.
