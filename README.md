# 📚 API Documentation

This document describes the available API endpoints for **user api** and **highlight api**. 

---

## 🧑‍💻 Authentication API

### 1. **Register User**:  
`POST /api/authenticaiton/register`  
**Request**:  
```
{ 
  "Name": "Test User", 
  "Email": "testuser@gmail.com", 
  "Password": "Test@1234", 
  "Avatar": "https://some-avatar-url.com", 
  "WebsiteUrl": "https://www.example.com" 
}
```
Response: HTTP 201 Created 🎉

2. Login User:
POST /api/authenticaiton/login
Request:
```
 

{ 
  "Email": "testuser@gmail.com", 
  "Password": "Test@1234" 
}
```
Response: HTTP 200 OK ✅ (JWT Token)

3. Get User Profile:
GET /api/authenticaiton/userId
```
Request: Authorization: Bearer <JWT_Token>
```
Response: HTTP 200 OK 📄 - User profile

5. Update User Profile:
PUT /api/authenticaiton/userId
Request:


```
{ 
  "Name": "Updated User", 
  "Email": "updateduser@gmail.com", 
  "Avatar": "https://new-avatar-url.com", 
  "WebsiteUrl": "https://new-website.com" 
}
```
Response: HTTP 200 OK 🔄 - Updated user profile

🏈 Highlight API
1. Calculate Completion Percentage:
POST /api/highlight/completion-percentage
Request:


```
[
  { "result": "incomplete", "receiver": "Demaryius Thomas", "distance": 0.7 },
  { "result": "complete", "receiver": "Tim Patrick", "distance": 0.9 },
  { "result": "complete", "receiver": "Demaryius Thomas", "distance": 0.3 },
  { "result": "incomplete", "receiver": "Tim Patrick", "distance": 0.9 },
  { "result": "complete", "receiver": "Tim Patrick", "distance": 0.8 },
  { "result": "complete", "receiver": "Demaryius Thomas", "distance": 0.1 },
  { "result": "interception", "receiver": "Demaryius Thomas", "distance": 0.4 }
]
```
Response: HTTP 200 OK 📊 - Completion percentage per receiver

2. Find Longest Completed Pass:
POST /api/highlight/longest-completed-pass
Request:


```
[
  { "result": "incomplete", "receiver": "Demaryius Thomas", "distance": 0.7 },
  { "result": "complete", "receiver": "Tim Patrick", "distance": 0.9 },
  { "result": "complete", "receiver": "Demaryius Thomas", "distance": 0.3 },
  { "result": "incomplete", "receiver": "Tim Patrick", "distance": 0.9 },
  { "result": "complete", "receiver": "Tim Patrick", "distance": 0.8 },
  { "result": "complete", "receiver": "Demaryius Thomas", "distance": 0.1 },
  { "result": "interception", "receiver": "Demaryius Thomas", "distance": 0.4 }
]
```
Response: HTTP 200 OK 🏆 - Longest completed pass and receiver

🔐 Authorization
All endpoints that require authentication expect the JWT token in the Authorization header as Bearer <JWT_Token>.

📝 Example Request Flow
Register a new user: /api/Authentication/register
Login to obtain the JWT token: /api/Authentication/login
Use the JWT token for protected routes:
/api/Authentication/userId
/api/highlight/completion-percentage
/api/highlight/longest-completed-pass

🚫 Error Handling
400 Bad Request: Invalid request.
401 Unauthorized: Missing or invalid JWT token.
404 Not Found: Resource not found.
500 Internal Server Error: Server error.
