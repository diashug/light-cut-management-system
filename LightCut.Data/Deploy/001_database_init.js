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
);

db.createCollection('clients');
db.createCollection('suppliers');
db.createCollection('roles');
db.createCollection('orders');
db.createCollection('orderLines');
db.createCollection('machines');
db.createCollection('deliveryMethods');
db.createCollection('materials');
