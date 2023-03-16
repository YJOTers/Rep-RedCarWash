'use strict'
const { Router } = require('express');
const api = Router();
var colorDeVehiculoController = require('../controllers/colorDeVehiculoController');

api.get('/seleccionar_colorDeVehiculo/:ide', colorDeVehiculoController.seleccionar_colorDeVehiculo);
api.put('/actualizar_colorDeVehiculo/:id', colorDeVehiculoController.actualizar_colorDeVehiculo);
api.post('/insertar_colorDeVehiculo/', colorDeVehiculoController.insertar_colorDeVehiculo);
api.delete('/eliminar_colorDeVehiculo/:id', colorDeVehiculoController.eliminar_colorDeVehiculo);

module.exports = api;