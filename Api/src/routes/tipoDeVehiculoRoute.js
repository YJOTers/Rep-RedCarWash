'use strict'
const { Router } = require('express');
const api = Router();
var tipoDeVehiculoController = require('../controllers/tipoDeVehiculoController');

api.get('/seleccionar_tipoDeVehiculo/:ide', tipoDeVehiculoController.seleccionar_tipoDeVehiculo);
api.put('/actualizar_tipoDeVehiculo/:id', tipoDeVehiculoController.actualizar_tipoDeVehiculo);
api.post('/insertar_tipoDeVehiculo/', tipoDeVehiculoController.insertar_tipoDeVehiculo);
api.delete('/eliminar_tipoDeVehiculo/:id', tipoDeVehiculoController.eliminar_tipoDeVehiculo);

module.exports = api;