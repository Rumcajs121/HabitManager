
- [PL](#pl-)
- [EN](#en-)

---

## PL

### 📌 Cel projektu

🐰 HabbitManager to projekt edukacyjny, stworzony w celu rozwoju umiejętności **Fullstack Developera**, ze szczególnym naciskiem na:
<p align="center">
<img width="800" height="350" alt="image" src="https://github.com/user-attachments/assets/24725fec-a85e-4c2b-9add-1c017c1d5bf1" />
</p>

- naukę **React** i nowoczesnego **JavaScript**
- utrwalanie i rozwijanie wiedzy z **.NET**
- zrozumienie realnej architektury aplikacji
- praktykę **konteneryzacji** i podstaw DevOps

---

### 🏗️ Przegląd architektury

Aplikacja jest zbudowana w nowoczesnej, rozproszonej architekturze z wyraźnym podziałem odpowiedzialności.

#### 🔹 Frontend
- Aplikacja **React (SPA)**
- Hostowana niezależnie (np. Azure Static Web Apps albo IIS)
- Komunikuje się z backendem przez HTTP API

#### 🔹 API Gateway (YARP)
- **YARP (Yet Another Reverse Proxy)** działa jako pojedynczy punkt wejścia (single entry point)
- Routuje ruch do usług backendowych:
  - `/api` → Backend API
  - `/auth` → Identity Provider (Keycloak)

#### 🔹 Backend API
- **.NET API** z logiką biznesową
- Zabezpieczone przy pomocy **JWT Bearer**
- Waliduje tokeny wystawione przez Keycloak

#### 🔹 Uwierzytelnianie (Keycloak)
- **Keycloak** pełni rolę Identity Provider (IdP)
- Uwierzytelnianie przez **OpenID Connect (OIDC)**
- Flow: **Authorization Code Flow + PKCE**
- Odpowiada za logowanie użytkownika i wydawanie tokenów

#### 🔹 Baza danych (MongoDB)
- **MongoDB** przechowuje dane aplikacji (np. nawyki, wpisy)
- Nie przechowuje danych logowania użytkowników (od tego jest Keycloak)

---

### 🔐 Przepływ uwierzytelniania (uproszczony)

1. Użytkownik otwiera aplikację frontendową.
2. Frontend przekierowuje użytkownika do Keycloak (przez YARP pod `/auth`).
3. Użytkownik loguje się w Keycloak.
4. Keycloak zwraca **authorization code**.
5. Frontend wymienia kod na **access token** (OIDC + PKCE).
6. Frontend wywołuje Backend API z nagłówkiem:
   `Authorization: Bearer <token>`
7. Backend API waliduje token i przetwarza żądanie.

---

### 🐳 Infrastruktura (Docker)

- Usługi backendowe (API, Keycloak, MongoDB) są uruchamiane w kontenerach **Docker**
- Usługi są izolowane w prywatnej sieci Dockera
- Publicznie wystawiona jest tylko brama **YARP**

---

### 🎯 Główne cele

- zbudować “produkcyjną” aplikację fullstack w wersji edukacyjnej
- nauczyć się bezpiecznego logowania (OIDC + PKCE)
- przećwiczyć architekturę z gateway oraz separacją usług
- rozwinąć praktyczne umiejętności DevOps

---

### 🗺️ Schemat architektury

Schemat przedstawia:
- użytkownika korzystającego z aplikacji **React**
- komunikację frontendu z backendem poprzez **YARP**
- routing do:
  - **Keycloak** (`/auth`) – logowanie i tokeny
  - **Backend API** (`/api`) – logika biznesowa
- komunikację backendu z **MongoDB**

---

## EN

### 📌 Project purpose

HabbitManager is an educational project created to build **Fullstack Developer** skills, with a focus on:
<p align="center">
<img width="800" height="350" alt="image" src="https://github.com/user-attachments/assets/24725fec-a85e-4c2b-9add-1c017c1d5bf1" />
</p>

- learning **React** and modern **JavaScript**
- maintaining and improving **.NET** knowledge
- understanding real-world application architecture
- practicing basic DevOps workflows

---

### 🏗️ Architecture overview

The application uses a modern distributed architecture with clear separation of concerns.

#### 🔹 Frontend
- **React SPA**
- Hosted separately (e.g., Azure Static Web Apps or IIS)
- Communicates with the backend via HTTP API

#### 🔹 API Gateway (YARP)
- **YARP (Yet Another Reverse Proxy)** acts as a single entry point
- Routes traffic to backend services:
  - `/api` → Backend API
  - `/auth` → Identity Provider (Keycloak)

#### 🔹 Backend API
- **.NET API** containing business logic
- Secured with **JWT Bearer**
- Validates tokens issued by Keycloak

#### 🔹 Authentication (Keycloak)
- **Keycloak** acts as the Identity Provider (IdP)
- Authentication via **OpenID Connect (OIDC)**
- Flow: **Authorization Code Flow + PKCE**
- Responsible for user login and token issuance

#### 🔹 Database (MongoDB)
- **MongoDB** stores application data (e.g., habits, entries, configuration)
- It does **not** store user credentials (Keycloak handles authentication)

---

### 🔐 Authentication flow (simplified)

1. The user opens the frontend application.
2. The frontend redirects the user to Keycloak (through YARP at `/auth`).
3. The user logs in in Keycloak.
4. Keycloak returns an **authorization code**.
5. The frontend exchanges the code for an **access token** (OIDC + PKCE).
6. The frontend calls the Backend API with:
   `Authorization: Bearer <token>`
7. The Backend API validates the token and processes the request.

---

### 🐳 Infrastructure (Docker)

- Backend services (API, Keycloak, MongoDB) are containerized with **Docker**
- Internal services are isolated within a private Docker network
- Only the **YARP gateway** is exposed publicly

---

### 🎯 Goals

- build a real-world fullstack application (educational scope)
- learn secure authentication using OIDC + PKCE
- practice a gateway-based, microservice-like architecture
- improve practical Docker/DevOps skills

---

### 🗺️ Architecture diagram

The diagram illustrates:
- a user interacting with the **React** frontend
- frontend communication through **YARP**
- routing to:
  - **Keycloak** (`/auth`) – login and token issuance
  - **Backend API** (`/api`) – business logic
- backend communication with **MongoDB**
