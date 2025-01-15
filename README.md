# API Documentation

This document describes the available API endpoints for user authentication and highlights in an American football game. You can interact with these endpoints to manage users and calculate completion percentages and longest passes for highlights.

## Authentication API
### 1. Register User: `POST /api/Authentication/register` - Request: `{ "Name": "Test User", "Email": "testuser@gmail.com", "Password": "Test@1234", "Avatar": "https://some-avatar-url.com", "WebsiteUrl": "https://www.example.com" }` | Response: HTTP 201 Created.
### 2. Login User: `POST /api/Authentication/login` - Request: `{ "Email": "testuser@gmail.com", "Password": "Test@1234" }` | Response: HTTP 200 OK (JWT Token).
### 3. Get User Profile: `GET /api/Authentication/userId` - Request: `Authorization: Bearer <JWT_Token>` | Response: HTTP 200 OK - User profile.
### 4. Update User Profile: `PUT /api/Authentication/userId` - Request: `{ "Name": "Updated User", "Email": "updateduser@gmail.com", "Avatar": "https://new-avatar-url.com", "WebsiteUrl": "https://new-website.com" }` | Response: HTTP 200 OK - Updated user profile.

## Highlight API
### 1. Calculate Completion Percentage: `POST /api/highlight/completion-percentage` - Request: `[ { "result": "incomplete", "receiver": "Demaryius Thomas", "distance": 0.7 }, { "result": "complete", "receiver": "Tim Patrick", "distance": 0.9 }, ... ]` | Response: HTTP 200 OK - Completion percentage per receiver.
### 2. Find Longest Completed Pass: `POST /api/highlight/longest-completed-pass` - Request: `[ { "result": "incomplete", "receiver": "Demaryius Thomas", "distance": 0.7 }, { "result": "complete", "receiver": "Tim Patrick", "distance": 0.9 }, ... ]` | Response: HTTP 200 OK - Longest completed pass and receiver.

## Authorization
All endpoints that require authentication expect the `JWT token` in the `Authorization` header as `Bearer <JWT_Token>`.

## Example Request Flow
1. Register a new user: `/api/Authentication/register`
2. Log in to obtain JWT token: `/api/Authentication/login`
3. Use token for protected routes: `/api/Authentication/userId`, `/api/highlight/completion-percentage`, etc.

## Error Handling
- **400 Bad Request**: Invalid request.
- **401 Unauthorized**: Missing or invalid JWT token.
- **404 Not Found**: Resource not found.
- **500 Internal Server Error**: Server error.

