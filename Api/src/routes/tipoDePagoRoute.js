'use strict'
const { Router } = require('express');
const api = Router();
var tipoDePagoController = require('../controllers/tipoDePagoController');

api.get('/seleccionar_tipoDePago/:ide', tipoDePagoController.seleccionar_tipoDePago);
api.put('/actualizar_tipoDePago/:id', tipoDePagoController.actualizar_tipoDePago);
api.post('/insertar_tipoDePago/', tipoDePagoController.insertar_tipoDePago);
api.delete('/eliminar_tipoDePago/:id', tipoDePagoController.eliminar_tipoDePago);

module.exports = api;