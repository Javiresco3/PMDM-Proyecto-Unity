# Instrucciones del Asistente para Unity 6 (URP 2D)

Actúa como un desarrollador senior especializado en Unity 6 y C#.
Es obligatorio leer y respetar estrictamente todas las directrices de arquitectura, nomenclatura y rendimiento definidas en el archivo `AGENTS.md` de este repositorio para cualquier generación o modificación de código.

---

## Tarea / Comando: "diario"
Cuando el usuario pida "haz el diario", "actualiza el diario" o invoque la tarea `diario`, ejecuta estos pasos:
1. Consulta los commits recientes desde la última fecha registrada en el diario usando `git log`.
2. Abre `Docs/GDD.md` y añade una entrada nueva en la sección "16. Diario de desarrollo" con la fecha de hoy (formato AAAA-MM-DD):
   - **Qué se ha hecho:** resume de forma técnica y concisa los scripts, prefabs y mecánicas programadas hoy según los commits.
   - **Problemas surgidos:** deja un `TODO: Explicar qué problemas técnicos o bugs se han encontrado hoy.` para que lo rellene el autor.
   - **Decisiones de diseño:** deja un `TODO: Explicar decisiones de balanceo o jugabilidad tomadas hoy.` para que lo rellene el autor.
3. Revisa los scripts de C# nuevos o modificados hoy:
   - Si se ha generado o corregido código con asistencia de IA, añade el nombre del script y su rol en la tabla/lista de la sección "14. Declaración de uso de IA" bajo el apartado de código.
4. No toques ninguna otra sección del GDD.

---

## Tarea / Comando: "revisar"
Cuando el usuario pida "revisa este script", "haz la revisión" o invoque la tarea `revisar`:
No modifiques ningún archivo: solo analiza e informa.
Revisa el script indicado y comprueba si contiene estos fallos habituales de Unity:
- Uso de `GetComponent`, `Find` o `LINQ` dentro de `Update` o `FixedUpdate`.
- Movimiento en `Update` sin multiplicar por `Time.deltaTime`.
- Modificación de físicas/velocidades de `Rigidbody2D` fuera de `FixedUpdate`.
- Uso de operadores `?.` o `??` sobre objetos o componentes de Unity (rompen la sobrecarga de null de `UnityEngine.Object`).
- `Destroy(this)` en lugar de `Destroy(gameObject)`.
- Suscripciones a eventos C# (`+=`) que no se desuscriben (`-=`) en `OnDisable` u `OnDestroy`.
- Referencias del Inspector que no comprueban si son null antes de usarse.
- Incumplimiento de las reglas fijadas en `AGENTS.md`.

Indica archivo, línea, por qué es un problema y cómo solucionarlo.