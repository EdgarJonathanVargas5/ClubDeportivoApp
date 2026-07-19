# ClubDeportivoApp ⚽

Sistema de gestión interna para un Club Deportivo desarrollado en **.NET Core** utilizando la arquitectura **MVC (Modelo-Vista-Controlador)** en una aplicación de consola interconectada con una base de datos relacional mediante **Entity Framework Core**.

Este proyecto fue diseñado con un fuerte enfoque en la **Programación Orientada a Objetos (POO)**.

---

## 🛠️ Tecnologías y Herramientas Utilizadas

*   **Lenguaje:** C# (.NET 10.0)
*   **Patrón de Arquitectura:** MVC (Model-View-Controller)
*   **Persistencia / ORM:** Entity Framework Core (Mapeo Objeto-Relacional)
*   **Base de Datos:** MySQL

---

## 📐 Decisiones de Diseño y Arquitectura

### 1. Modelado de Datos y Orientación a Objetos (POO)
*   **Abstracción e Interfaces:** Uso de la interfaz `IParticipante` para definir el contrato base de los integrantes del club.
*   **Herencia (Table-Per-Type / TPT):** Implementación de la clase abstracta base `Participante`, de la cual heredan de manera especializada `Jugador` y `Entrenador`, optimizando la reutilización de código para atributos compartidos (DNI, Nombre, Apellido).

### 2. Separación de Responsabilidades (MVC)
*   **Models:** Clases puras de C# (POCO) encargadas de representar el dominio del negocio y las reglas de validación relacional.
*   **Views:** Módulos de consola aislados dedicados exclusivamente a la interacción con el usuario (renderizado de tablas formateadas, captura y parseo de inputs mediante `TryParse`).
*   **Controllers:** Orquestadores del flujo de la aplicación. Manejan la lógica de negocio y gestionan de forma segura el ciclo de vida del contexto de la base de datos (`ClubDbContext`).

---

## 📋 Características Principales

El sistema cuenta con un menú interactivo por consola con las siguientes operaciones:

1.  **Registrar Jugador:** Alta de jugadores validando unicidad de DNI.
2.  **Registrar Entrenador:** Registro de directores técnicos en el sistema.
3.  **Registrar Equipo:** Creación de equipos asignando un entrenador único.
4.  **Asociar Jugador a Equipo:** Vinculación de un jugador libre a un equipo existente.
5.  **Listar todos los Equipos:** Muestra los equipos registrados junto a su respectivo entrenador asignado.
6.  **Listar Equipo por Código:** Vista de detalle profundo que muestra la información del equipo y la nómina completa de sus jugadores ordenados alfabéticamente por apellido.
7.  **Expulsar Jugador:** Remueve un jugador del torneo y limpia su vinculación del equipo de forma segura.
8.  **Listar Participantes:** Reporte general de todas las personas registradas especificando su rol (Jugador/Entrenador).
9.  **Listar Entrenadores:** Reporte específico de los directores técnicos y sus vías de contacto.

---

## ⚙️ Configuración e Instalación Local

Para clonar y ejecutar este proyecto de forma local, seguí estos pasos:

### Prerrequisitos
*   SDK de .NET 10.0 o superior instalado.
*   Servidor MySQL activo (ej. a través de MAMP, Docker o instalación nativa).

### Pasos
1.  **Clonar el repositorio:**
    ```bash
    git clone https://github.com/EdgarJonathanVargas5/ClubDeportivoApp.git
    cd ClubDeportivoApp
    ```

2.  **Configurar las credenciales:**
    Creá un archivo `appsettings.json` en la raíz del proyecto y colocá los datos de tu servidor local:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;database=clubdeportivo_db;user=TU_USUARIO;password=TU_CONTRASEÑA"
      }
    }
    ```

3.  **Aplicar Migraciones (Crear la Base de Datos):**
    Ejecutá el siguiente comando en la terminal para que Entity Framework genere automáticamente las tablas e índices en tu servidor MySQL:
    ```bash
    dotnet ef database update
    ```

4.  **Ejecutar la Aplicación:**
    ```bash
    dotnet run
