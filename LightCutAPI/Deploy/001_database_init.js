// Create DB
db = db.getSiblingDB('LIGHTCUT_SGI_DB');

// Create Users collection
db.createCollection('users');

db.getCollection('users').insert(
    {
        "name": "Super User",
        "email": "hmdias@gmail.com",
        "password": "super.user",
        "created_at": ISODate(),
        "updated_at": null,
        "deleted_at": null
    }
)

