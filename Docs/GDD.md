# Nombre del juego - Documento de diseño (GDD)

## 1. Ficha del juego

| Campo | Detalle |
|-------|---------|
| Título | Resc |
| Autor/a | Javier Búa Martínez |
| Género | Tower Defense / Estrategia / Habilidad |
| 2D / 3D | 2D |
| Plataformas | Windows |
| Versión de Unity y pipeline | Unity 6 - URP (Universal 2D) |
| Público objetivo y PEGI | Todos los públicos, PEGI 7 |
| Duración de una partida | 10 - 15 min / 3 - 5 min por nivel |
| Repositorio | https://github.com/Javiresco3/PMDM-Proyecto-Unity |
| Página de itch.io | |

## 2. Concepto

### Resumen
Resc es un videojuego estilo *Tower Defense* en 2D con vista cenital donde el jugador protege un altar arcano frente a oleadas de criaturas. La generación de maná no depende solo de derrotar enemigos, sino de hacer runas bajo presión de tiempo.

### Pilares de diseño
1. **Doble foco táctico:** Coordinar el posicionamiento estratégico de las defensas en el mapa mientras se resuelven secuencias rúnicas para mantener el flujo constante de maná.
2. **Respuesta inmediata (Game Feel):** Priorizar que cada acción ofrezca una respuesta audiovisual clara y satisfactoria.
3. **Progresión escalonada:** Introducir mecánicas, torres y comportamientos de enemigos de forma gradual nivel a nivel, garantizando una curva de aprendizaje justa.
4. **Accesibilidad en los controles:** Mantener una interacción limpia e intuitiva mediante ratón o teclado para evitar frustración mecánica.

### Referencias
* **Bloons TD:** La perspectiva cenital bidimensional, el desplazamiento de enemigos a lo largo de rutas predefinidas y la colocación estratégica de defensas con áreas de alcance delimitadas.
* **Runeomicon:** La temática mágica y la mecánica de realizar runas bajo presión constante.

### Qué lo hace diferente
Elimina los tiempos muertos típicos del género *Tower Defense*. En lugar de esperar a que se acumulen recursos, el jugador participa activamente: cuantas más secuencias rúnicas complete, más maná obtendrá para desplegar nuevas torres, aplicar mejoras o desatar habilidades de control de masas.

---

## 3. Historia y ambientación

### Premisa
En las ruinas olvidadas del Valle de Resc yace un monolito arcano que mantiene sellada la energía elemental de la región. Una corrupción subterránea ha despertado, manifestándose como oleadas de criaturas que marchan decididas a quebrar el núcleo y consumir su poder residual.

### Protagonista
El jugador toma el papel del Custodio de Resc, una entidad mística ligada al altar que canaliza runas arcanas desde su santuario para invocar centinelas y elementales que frenen la invasión.

### Cómo se cuenta la historia
La narrativa se integra mediante breves cuadros introductorios de texto antes de iniciar cada nivel, la evolución estética de los escenarios y los mensajes contextuales al alcanzar las pantallas de victoria y derrota.

## 4. Jugabilidad

### Objetivo
Defender el monolito arcano situado al final del sendero evitando que las criaturas enemigas agoten su salud a lo largo de las distintas oleadas de cada nivel.

### Bucle de juego
1. **Analizar la ruta:** Identificar por dónde avanzarán los enemigos en la oleada actual.
2. **Canalizar maná:** Completar patrones de runas en el altar para generar maná rápidamente.
3. **Desplegar y mejorar defensas:** Colocar torretas/criaturas en las casillas adyacentes al camino y mejorar sus atributos.
4. **Intervención directa:** Utilizar habilidades activas de control o daño cuando la línea de defensa se vea desbordada o en situaciones estratégicas.
5. **Fin de oleada:** Evaluar bajas, recoger maná residual y preparar la siguiente fase.

### Condiciones de victoria y derrota
* **Victoria:** Completar con éxito todas las oleadas del nivel manteniendo al menos 1 punto de vida en el monolito.
* **Derrota:** Si la salud del monolito llega a 0 tras filtrarse demasiados enemigos.

### Progresión
* **Nivel 1:** Ruta simple, enemigos estándar lentos, runas simples y torre/criatura elemental básica.
* **Nivel 2:** Ruta con bifurcación, enemigos ágiles/resistentes, runas de complejidad media, desbloqueo de torres/criaturas y habilidad activa de área.
* **Nivel 3:** Múltiples rutas, oleada con jefe final de alto aguante, runas de complejidad alta y torres/criaturas nuevas.

---

## 5. Mecánicas

| Mecánica | Descripción | Control | Nivel en el que aparece |
|----------|-------------|---------|-------------------------|
| **Invocación de defensas** | Colocar estructuras defensivas en nodos designados del mapa gastando maná. | Clic izquierdo | Nivel 1 |
| **Forja de Runas** | Resolver runas en un panel interactivo para obtener maná inmediato. | Por definir (Q-W-E-R / Clic ratón) | Nivel 1 |
| **Mejora de atributos** | Incrementar el daño, alcance o cadencia de una torre existente pagando maná. | Clic sobre torre + interfaz | Nivel 2 |
| **Habilidad activa: Nova de Hielo** | Congela y ralentiza a los enemigos en un radio determinado durante unos segundos. | Tecla 1 + Clic en mapa | Nivel 2 |
| **Habilidad activa: Tormenta Ígnea** | Daño masivo de fuego en área para despejar acumulaciones de enemigos críticos. | Tecla 2 + Clic en mapa | Nivel 3 |

## 6. Controles

| Acción | Teclado | Mando |
|--------|---------|-------|
| | | |

### Aprendizaje de controles

## 7. Niveles

### Nivel 1: Nombre
* **Objetivo:**
* **Elemento nuevo:**
* **Escena de Unity:**
* **Duración y dificultad:**
* **Contenido opcional:**

### Nivel 2: Nombre
* **Objetivo:**
* **Elemento nuevo:**
* **Escena de Unity:**
* **Duración y dificultad:**
* **Contenido opcional:**

### Nivel 3: Nombre
* **Objetivo:**
* **Elemento nuevo:**
* **Escena de Unity:**
* **Duración y dificultad:**
* **Contenido opcional:**

## 8. Personajes y enemigos

### Personaje del jugador

### Enemigos y obstáculos

## 9. Interfaz y flujo de pantallas

### Diagrama de flujo

### HUD

### Menús

## 10. Dirección de arte

### Estilo visual

### Paleta de colores

### Tipografías

### Moodboard

### Justificación de la coherencia

## 11. Sonido y música

### Estilo musical

### Pistas de música

### Efectos de sonido

### Organización del audio

## 12. Efectos visuales y game feel

### Efectos visuales y partículas

### Iluminación

### Cámara

### Técnicas de game feel

## 13. Recursos de terceros

| Recurso | Tipo | Autor | Licencia | Enlace | Dónde se usa |
|---------|------|-------|----------|--------|--------------|
| | | | | | |

## 14. Declaración de uso de IA

### Herramientas utilizadas
* **Gemini (Google):** Asistente utilizado como apoyo de redacción, estructuración documental y soporte técnico puntual.

### Áreas de uso
* **Redacción y formalización del GDD:** Apoyo en la estructuración de la documentación y en la redacción formal de los conceptos, mecánicas y apartados de diseño definidos por el autor.
* **Código (en desarrollo):** A medida que se desarrollen los scripts del juego, se registrará aquí de forma detallada cada script o algoritmo en el que se haya utilizado asistencia de IA para su generación, corrección o depuración.

### Modificaciones y adaptaciones
* Todas las propuestas de redacción y estructuración han sido revisadas, filtradas y validadas por el autor para asegurar que reflejan fielmente el diseño previsto.
* Todo el código que se apoye en IA se estudiará y comprenderá en su totalidad antes de incorporarse al proyecto, garantizando la capacidad de defenderlo y modificarlo en clase.

### Confirmación de recursos no generados por IA
* Se confirma que **ningún recurso gráfico, sprite, modelo 3D, textura, música, efecto de sonido ni efecto visual** ha sido generado mediante herramientas de inteligencia artificial generativa.
* Todos los assets de terceros empleados provendrán de repositorios y autores que garanticen no usar IA en su creación, y contarán con sus licencias correspondientes declaradas en la sección 13.

## 15. Aspectos técnicos

### Estructura del proyecto

### Arquitectura del código

### Paquetes de Unity

### Guardado de datos

### Problemas técnicos y soluciones

### Errores conocidos

## 16. Diario de desarrollo

### AAAA-MM-DD
* **Qué se ha hecho:**
* **Problemas surgidos:**
* **Decisiones de diseño:**

## 17. Pruebas con jugadores

### Prueba 1
* **Tester y versión:**
* **Observaciones:**
* **Cambios realizados:**

### Prueba 2
* **Tester y versión:**
* **Observaciones:**
* **Cambios realizados:**

### Prueba 3
* **Tester y versión:**
* **Observaciones:**
* **Cambios realizados:**

## 18. Postmortem

### Aspectos positivos

### Dificultades y recortes

### Diferencias con la idea original

### Aprendizajes

### Conclusiones