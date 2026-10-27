# Phase 17 — Keycloak infrastructure for API Gateway

## Goal

Integrate Keycloak with the API Gateway to authenticate incoming requests using JWT access tokens, configure authentication services and middleware, and verify the authentication flow using a Keycloak Realm, Client, and User.

## 1. Add Keycloak to Docker Compose

* Add the Keycloak service to `docker-compose.yml`.
* Configure the development startup command, bootstrap administrator credentials, port mapping, and persistent volume.
* Ensure Keycloak is accessible from both the host machine and the API Gateway container.

## 2. Configure Keycloak Settings

* Add the required Keycloak configuration to `appsettings.Development.json`.
* Configure the Realm Authority, Audience, and HTTPS metadata requirements.
* Ensure the configuration matches the Keycloak deployment and token validation requirements.

## 3. Configure Authentication in DependencyInjection

* Configure JWT Bearer authentication using `AddAuthentication()` and `AddJwtBearer()`.
* Configure token validation, including issuer, audience, signing key, and token lifetime.
* Register authorization services using `AddAuthorization()`.
* Keep the configuration limited to token validation; exclude user management and Admin REST API integration.

## 4. Register Authentication in Program.cs

* Register the authentication infrastructure in the API Gateway's dependency injection container.
* Add `UseAuthentication()` and `UseAuthorization()` in the correct middleware order.
* Ensure authentication and authorization are applied to the appropriate YARP routes.

## 5. Configure Keycloak Realm, Client, and User

* Create a dedicated Realm for the application.
* Create and configure a Client for authentication.
* Configure the appropriate client authentication and redirect settings.
* Create a test User and assign credentials.
* Configure the required Audience and token claims, where applicable.

## 6. Verify the Authentication Flow

* Log in through Keycloak using the test User and obtain an access token.
* Send a request through the API Gateway with the token in the `Authorization: Bearer` header.
* Verify that requests with valid tokens are accepted.
* Verify that requests without a token or with an invalid or expired token are rejected.
* Confirm that the Gateway correctly forwards authorized requests to the downstream services.

## Expected Result

The API Gateway authenticates incoming requests using Keycloak-issued JWT access tokens. Protected routes accept valid tokens and reject unauthenticated requests, without requiring a separate user-management integration.
