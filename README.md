# StudentAdminPortal.API

## Requirements
- .NET 5
- SQL database server

## Endpoints
### GET
- `/Students` - returns list of students
    ```json
    {
    "id": "83045206-9970-4d13-8def-008091160c88",
    "firstName": "Santos",
    "lastName": "Valencia",
    "dateOfBirth": "1989-06-11T00:00:00",
    "email": "Santos.Valencia@gmaill.com",
    "mobile": 91254684826,
    "profileImageUrl": null,
    "genderId": "6f08fab6-c62e-4306-9d77-c82c9c6a23ac",
    "gender": {
      "id": "6f08fab6-c62e-4306-9d77-c82c9c6a23ac",
      "description": "Male"
    },
    "address": {
      "id": "7b590994-24be-4d64-ae78-c261d1f12aba",
      "physicalAddress": null,
      "postalAddress": null,
      "studentId": "83045206-9970-4d13-8def-008091160c88"
    }
    ```