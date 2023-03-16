'use strict'
const { Router } = require('express');
const api = Router();
var marcaDeVehiculoController = require('../controllers/marcaDeVehiculoController');

api.get('/seleccionar_marcaDeVehiculo/:ide', marcaDeVehiculoController.seleccionar_marcaDeVehiculo);
api.put('/actualizar_marcaDeVehiculo/:id', marcaDeVehiculoController.actualizar_marcaDeVehiculo);
api.post('/insertar_marcaDeVehiculo/', marcaDeVehiculoController.insertar_marcaDeVehiculo);
api.delete('/eliminar_marcaDeVehiculo/:id', marcaDeVehiculoController.eliminar_marcaDeVehiculo);

module.exports = api;