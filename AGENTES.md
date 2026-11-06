# Proyecto: Resc (Tower Defense 2D)

Videojuego de estrategia Tower Defense en 2D desarrollado con Unity 6 (URP 2D).
El jugador controla a un hechicero oscuro resurgido que defiende un monolito arcano
frente a oleadas de humanos invasores usando esbirros invocados y secuencias rúnicas (Q-W-E-R).
El GDD completo está en `Docs/GDD.md`.

## Tecnología
- Unity 6 (6000.5.11f1), Universal 2D (URP).
- Sistema de entrada: Input System (acciones de teclado y ratón). No usar la clase Input antigua.
- Pixel Art en escala 16x16 (Top-Down).
- UI: Canvas de Unity con TextMeshPro.

## Estructura de carpetas
- `Assets/_Project/Scripts/` con subcarpetas:
  - `Enemies/` (movimiento de tropas humanas, vida, pathfinding por waypoints).
  - `Towers/` (esbirros/tótems de defensa, detección de rango, disparo).
  - `Runes/` (gestión de secuencias rúnicas QWER, temporizadores).
  - `Managers/` (GameManager, WaveManager, ManaManager).
  - `Projectiles/` (orbes mágicos, colisiones).
  - `UI/` (HUD, contadores, barras de vida).
- `Assets/_Project/Prefabs/`, `Assets/_Project/Scenes/`.
- `Assets/ThirdParty/`: assets de Pipoya, Superdark, 0x72, FoozleCC y Alkakrab. NO modificar nada de esta carpeta.

## Arquitectura
- `GameManager` y gestores globales se comunican mediante eventos C# (`event Action`), evitando dependencias circulares.
- Prohibido terminantemente usar `GameObject.Find`, `FindAnyObjectByType` o `GetComponent` dentro de métodos `Update` o `FixedUpdate`.
- El movimiento de proyectiles o colisiones por físicas se realiza en `FixedUpdate` usando `Rigidbody2D`.
- Movimiento de enemigos por interpolación entre waypoints en `Update` mediante `Time.deltaTime`.

## Estilo de código
- Clases, métodos y propiedades en PascalCase; variables en camelCase.
- Código en inglés; comentarios y explicaciones en español.
- Variables del Inspector: siempre `[SerializeField] private`, nunca `public`.
- Componentes obligatorios marcados con `[RequireComponent]`.
- Asignación de componentes en `Awake()`.
- Orden dentro del script: campos serializados, variables privadas, métodos de ciclo de vida Unity (Awake, Start, Update), métodos públicos, métodos privados.

## Reglas para el Agente / IA
- No instalar paquetes nuevos ni modificar archivos en `ProjectSettings` sin consultar.
- No borrar, mover ni renombrar archivos `.meta` desde el exterior para evitar referencias rotas en Unity.
- No editar a mano archivos de escenas (`.unity`) ni de prefabs (`.prefab`).
- No modificar scripts no relacionados con la tarea solicitada.
- Explicar siempre el código generado de forma didáctica para que el alumno pueda defenderlo en clase.
- Indicar siempre qué referencias o componentes deben configurarse a mano en el Inspector de Unity tras crear un script.