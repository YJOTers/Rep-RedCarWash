'use strict'
const { Router } = require('express');
const api = Router();
var serviciosController = require('../controllers/serviciosController');

api.get('/seleccionar_servicios/:ide', serviciosController.seleccionar_servicios);
api.put('/actualizar_servicios/:id', serviciosController.actualizar_servicios);
api.post('/insertar_servicios/', serviciosController.insertar_servicios);
api.delete('/eliminar_servicios/:id', serviciosController.eliminar_servicios);

module.exports = api;