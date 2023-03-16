'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar registro de vehiculo
const seleccionar_regDeVehiculo = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM vista_registroDeVehiculo WHERE id_uc_rv = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar registro de vehiculo
const actualizar_regDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE registro_de_vehiculo SET ${connection.escape(req.body)} WHERE id_rv = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar registro de vehiculo
const insertar_regDeVehiculo = async function(req, res){
    const sql = `INSERT INTO registro_de_vehiculo SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar registro de vehiculo
const eliminar_regDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM registro_de_vehiculo WHERE id_rv = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_regDeVehiculo,
    actualizar_regDeVehiculo,
    insertar_regDeVehiculo,
    eliminar_regDeVehiculo
};