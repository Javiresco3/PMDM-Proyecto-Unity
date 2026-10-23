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
* **Bloons TD:** La perspectiva cenital bidimensional, el desplazamiento de enemigos a lo largo de rutas predefinidas y la colocación estratégica de defensas en nodos con áreas de alcance delimitadas.
* **Runeomicon:** La ambientación arcana y la mecánica de resolver runas bajo presión de tiempo para obtener recursos mágicos.

### Qué lo hace diferente
Elimina los tiempos muertos típicos del género *Tower Defense*. En lugar de esperar a que se acumulen recursos, el jugador participa activamente: cuantas más secuencias rúnicas complete, más maná obtendrá para desplegar nuevas torres, aplicar mejoras o desatar habilidades de control de masas.

---

## 3. Historia y ambientación

### Premisa
Tras siglos de confinamiento, un antiguo hechicero oscuro resurge en las ruinas del Valle de Resc para reclamar su dominio mediante el poder de un monolito arcano. Al advertir su despertar, los reinos humanos organizan expediciones militares inmediatas para marchar sobre el santuario y destruir el obelisco antes de que recupere su fuerza total.

### Protagonista
El jugador encarna al hechicero oscuro resurgido. Desde su altar, canaliza energía rúnica para invocar esbirros, espectros y tótems sombríos que aniquilan a las tropas humanas invasoras a lo largo del sendero.

### Cómo se cuenta la historia
A través de breves textos introductorios al inicio de cada nivel que contextualizan el avance del ejército humano, la degradación visual del entorno hacia parajes cada vez más corruptos y pantallas de victoria o derrota con mensajes narrativos.

## 4. Jugabilidad

### Objetivo
Defender el monolito arcano situado al final del sendero evitando que las tropas invasoras agoten su salud a lo largo de las distintas oleadas de cada nivel.

### Bucle de juego
1. **Analizar la ruta:** Identificar por dónde avanzarán los enemigos en la oleada actual.
2. **Canalizar maná:** Completar patrones de runas en el altar para generar maná rápidamente.
3. **Desplegar y mejorar defensas:** Invocar esbirros y estructuras en las casillas adyacentes al camino y mejorar sus atributos.
4. **Intervención directa:** Utilizar habilidades activas de control o daño cuando la línea de defensa se vea desbordada o en situaciones estratégicas.
5. **Fin de oleada:** Evaluar bajas, recoger maná residual y preparar la siguiente fase.

### Condiciones de victoria y derrota
* **Victoria:** Completar con éxito todas las oleadas del nivel manteniendo al menos 1 punto de vida en el monolito.
* **Derrota:** Si la salud del monolito llega a 0 tras filtrarse demasiados enemigos.

### Progresión
* **Nivel 1:** Sendero de pradera abierta, invasores humanos básicos (aldeanos y milicia ligera), runas simples y esbirro oscuro básico de proyectil rápido.
* **Nivel 2:** Caminos bifurcados con terreno corrupto, tropas humanas con escudos y armaduras intermedias, runas de complejidad media, invocación de ralentización y habilidad activa de área (Nova de Hielo).
* **Nivel 3:** Múltiples accesos al monolito, asalto de la caballería pesada y el Comandante Real (jefe final), runas complejas y esbirros de daño masivo en área.

---

## 5. Mecánicas

| Mecánica | Descripción | Control | Nivel en el que aparece |
|----------|-------------|---------|-------------------------|
| **Invocación de esbirros oscuros** | Invocar criaturas y tótems defensivos en nodos del mapa gastando maná. | Clic izquierdo | Nivel 1 |
| **Forja de Runas** | Resolver secuencias de runas en un panel interactivo para generar maná inmediato. | Por definir (Q-W-E-R / Clic ratón) | Nivel 1 |
| **Mejora de atributos** | Incrementar daño, alcance o cadencia de una criatura invocada pagando maná. | Clic sobre unidad + interfaz | Nivel 2 |
| **Habilidad activa: Nova de Hielo** | Congela y ralentiza a los enemigos en un radio determinado durante unos segundos. | Tecla 1 o Clic HUD + Clic en mapa | Nivel 2 |
| **Habilidad activa: Tormenta Ígnea** | Daño masivo de fuego en área para despejar acumulaciones críticas de tropas. | Tecla 2 o Clic HUD + Clic en mapa | Nivel 3 |

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
| **Free RPG Tileset 16x16** | Gráfico (Tileset 2D) | Pipoya | Gratuito (Uso libre / TOS Pipoya) | https://pipoya.itch.io/free-rpg-tileset-16x16 | Terrenos abiertos, caminos y vegetación en los niveles |
| **16x16 Free NPC Pack** | Gráfico (Sprites 2D) | Superdark | Gratuito / CC0 | https://superdark.itch.io/16x16-free-npc-pack | Tropas humanas invasoras (aldeanos, soldados, caballeros) |
| **Enchanted Forest Characters** | Gráfico (Sprites 2D) | Superdark | Gratuito / CC0 | https://superdark.itch.io/enchanted-forest-characters | Comandante / Caballero dorado (Jefe final humano) |
| **Microfantasy** | Gráfico (Sprites 2D) | 0x72 | CC0 (Dominio Público) | https://0x72.itch.io/microfantasy | Esbirros oscuros invocados como defensas del jugador |
| **16x16 Dungeon Tileset II** | Gráfico (Sprites 2D) | 0x72 | CC0 (Dominio Público) | https://0x72.itch.io/dungeontileset-ii | Monolito arcano central y criaturas adicionales |
| **Pixel Magic Sprite Effects** | Gráfico (VFX 2D) | FoozleCC | Gratuito (Uso en juegos) | https://foozlecc.itch.io/pixel-magic-sprite-effects | Proyectiles elementales, magias de runas e impactos |
| **6 Tracks Music Pack** | Audio (Música) | Alkakrab | Gratuito con atribución | https://alkakrab.itch.io/6tracksmusipack | Música de fondo en niveles y menús |

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

### 2026-10-09
* **Qué se ha hecho:** Creación del repositorio unido a Unity y de la ficha de juego.
* **Problemas surgidos:** Me costó unir Unity con GitHub en un repositorio.
* **Decisiones de diseño:** Ninguna.

### 2026-10-12
* **Qué se ha hecho:** Se hacen los puntos: concepto, historia y ambientación, jugabilidad y mecánicas.
* **Problemas surgidos:** Ninguno.
* **Decisiones de diseño:** Se adopta un modelo de Tower Defense 2D cenital (estilo Bloons) con un sistema de resolución de secuencias rúnicas para acelerar la generación de maná.

### 2026-10-23
* **Qué se ha hecho:** Selección y auditoría definitiva de los assets visuales y de audio. Actualización del GDD para alinear historia, enemigos humanos y defensas oscuras con los paquetes elegidos.
* **Problemas surgidos:** Se detectaron incongruencias de perspectiva (mezcla de vista lateral con cenital) en los borradores iniciales de assets; se resolvió unificando todo bajo estándar Top-Down de 16x16 libre de IA.
* **Decisiones de diseño:** Los mapas serán abiertos mediante el tileset de Pipoya y las defensas serán esbirros oscuros invocados estáticos para reforzar la temática del hechicero frente a los invasores humanos.

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
