'use strict'
const { Router } = require('express');
const api = Router();
var regDeTipoLavadooController = require('../controllers/regDeTipoLavadoController');

api.get('/seleccionar_regDeTipoLavado/:ide', regDeTipoLavadooController.seleccionar_regDeTipoLavado);
api.put('/actualizar_regDeTipoLavado/:id', regDeTipoLavadooController.actualizar_regDeTipoLavado);
api.post('/insertar_regDeTipoLavado/', regDeTipoLavadooController.insertar_regDeTipoLavado);
api.delete('/eliminar_regDeTipoLavado/:id', regDeTipoLavadooController.eliminar_regDeTipoLavado);

module.exports = api;