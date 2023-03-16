'use strict'
const { Router } = require('express');
const api = Router();
var regDeVehiculoController = require('../controllers/regDeVehiculoController');

api.get('/seleccionar_regDeVehiculo/:ide', regDeVehiculoController.seleccionar_regDeVehiculo);
api.put('/actualizar_regDeVehiculo/:id', regDeVehiculoController.actualizar_regDeVehiculo);
api.post('/insertar_regDeVehiculo/', regDeVehiculoController.insertar_regDeVehiculo);
api.delete('/eliminar_regDeVehiculo/:id', regDeVehiculoController.eliminar_regDeVehiculo);

module.exports = api;