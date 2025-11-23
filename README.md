# EditorTextoSencillo

**Tarea Obligatoria UD1 - Desarrollo de Interfaces**

## 📋 Descripción del Proyecto

Editor de texto sencillo desarrollado en C# con .NET 9.0, implementando el patrón de diseño **MVC (Modelo-Vista-Controlador)**.

### 🎯 Características Principales
- **Arquitectura MVC**: Separación clara entre lógica de negocio, interfaz de usuario y control de flujo.
- **Interfaz intuitiva**: Diseño familiar con barra de menús y barra de estado informativa.
- **Gestión avanzada de archivos**: Soporte para múltiples codificaciones y historial de archivos recientes.
- **Herramientas de edición**: Búsqueda, reemplazo y formateo de texto.
- **Información en tiempo real**: Estadísticas de documento actualizadas automáticamente.

## 🏗️ Estructura del Proyecto

```
EditorTextoSencillo/
├── 📁 Controlador/
│   └── EditorTextoControlador.cs     # Coordina modelo y vista
├── 📁 Modelo/
│   └── EditorTextoModelo.cs          # Lógica de negocio y datos
├── 📁 Recursos/
│   └── 📁 Iconos/
│       └── EditorTextoSencillo.ico       # Icono de la aplicación
├── 📁 Vista/
│   ├── EditorTexto.cs                # Vista principal
│   ├── EditorTexto.Designer.cs       # Diseño de la interfaz
│   ├── EditorTexto.resx              # Recursos del formulario
│   └── IEditorTextoVista.cs          # Contrato de la vista
├── EditorTextoSencillo.csproj        # Proyecto de Visual Studio
├── EditorTextoSencillo.sln           # Solución del proyecto
└── Program.cs                        # Punto de entrada
README.md                             # Este archivo
```

## 🚀 Funcionalidades Implementadas

### 📁 Menú Archivo
- **Nuevo** (Ctrl+N): Crear nuevo documento
- **Abrir** (Ctrl+A): Abrir archivo existente
- **Abrir reciente**: Acceso rápido a últimos 10 archivos
- **Guardar** (Ctrl+G): Guardar archivo actual
- **Guardar como**: Guardar con nuevo nombre/ruta
- **Cerrar archivo**: Cerrar documento actual
- **Salir** (Ctrl+S): Salir de la aplicación

### ✏️ Menú Editar
- **Buscar** (Ctrl+B): Diálogo de búsqueda de texto
- **Ir a...**: Navegación rápida dentro del documento
  - **Inicio**: Ir al inicio del documento
  - **Línea**: Ir a línea específica
  - **Fin**: Ir al final del documento
- **Reemplazar** (Ctrl+R): Buscar y reemplazar texto

### 🎨 Menú Formato
- **Fuente**: Diálogo de selección de fuente y tamaño
- **Conversiones de texto**:
  - **MAYÚSCULAS**: Texto seleccionado a mayúsculas
  - **minúsculas**: Texto seleccionado a minúsculas
  - **Título**: Formato título (Cada Palabra Con Mayúscula)
  - **Oración**: Formato oración (Primera letra en mayúscula)

### 👁️ Menú Ver
- **Barra de estado** (Ctrl+H): Mostrar/ocultar barra de estado

### ❓ Menú Ayuda
- **Acerca de...**: Información de la aplicación y autora

## 📊 Barra de Estado
Información en tiempo real del documento:
- **Posición del cursor**: Línea y columna actual
- **Estadísticas**: Número de líneas, palabras y caracteres
- **Codificación**: Tipo de codificación del archivo (UTF-8, ASCII, etc.)

## 🛠️ Tecnologías y Componentes

### Entorno de Desarrollo
- **Visual Studio 2022/2023** (Recomendado)
- **.NET SDK 9.0** - Target: `net9.0-windows`
- **Windows Forms** (.NET Framework)

### Componentes .NET Esenciales
1. **System.Windows.Forms** - Para la interfaz gráfica
2. **System.Drawing** - Manipulación de fuentes y impresión
3. **System.Text** - Gestión de codificaciones
4. **System.IO** - Operaciones de archivo

### Patrones Implementados
- **MVC (Modelo-Vista-Controlador)**: Separación de responsabilidades
- **Observer Pattern**: Eventos para comunicación entre componentes
- **Dependency Injection**: Constructor injection en controlador

## 🔧 Instalación y Ejecución

### Prerrequisitos
- .NET SDK 9.0 o superior
- Visual Studio 2022/2023 (opcional)

### Compilación y Ejecución
```bash
# Con CLI de .NET
dotnet build
dotnet run

# O abrir la solución en Visual Studio
EditorTextoSencillo.sln
```

## 📝 Notas de Desarrollo

### Decisiones de Diseño
1. **RichTextBox** en lugar de TextBox para mejor soporte de texto
2. **Codificación automática** basada en BOM (Byte Order Mark)
3. **Límite de archivos recientes** a 10 para usabilidad
4. **Patrón MVC estricto** incluso en Windows Forms

### Características de Usabilidad Implementadas
- ✅ Iconos y atajos de teclado
- ✅ Confirmaciones para acciones destructivas

## 👩‍💻 Autora

**Lara Ridruejo Alcalde**  
*Desarrollo de Interfaces - DAM*  
*Tarea Obligatoria UD1*