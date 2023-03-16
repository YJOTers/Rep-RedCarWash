'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar tipo de vehiculo
const seleccionar_tipoDeVehiculo = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM tipo_de_vehiculo WHERE id_uc_tdv = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Actualizar tipo de vehiculo
const actualizar_tipoDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `UPDATE tipo_de_vehiculo SET ${connection.escape(req.body)} WHERE id_tdv = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar tipo de vehiculo
const insertar_tipoDeVehiculo = async function(req, res){
    const sql = `INSERT INTO tipo_de_vehiculo SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Eliminar tipo de vehiculo
const eliminar_tipoDeVehiculo = async function(req, res){
    const id = req.params.id;
    const sql = `DELETE FROM tipo_de_vehiculo WHERE id_tdv = ${connection.escape(id)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_tipoDeVehiculo,
    actualizar_tipoDeVehiculo,
    insertar_tipoDeVehiculo,
    eliminar_tipoDeVehiculo
};