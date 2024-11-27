'use strict'
const { Router } = require('express');
const api = Router();
var informeController = require('../controllers/informeController');

api.get('/seleccionar_informe/:ide', informeController.seleccionar_informe);
api.post('/insertar_informe/', informeController.insertar_informe);

module.exports = api;