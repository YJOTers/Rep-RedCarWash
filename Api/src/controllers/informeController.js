'use strict'
const util = require('util');
const connection = require('../bd/db');
const query = util.promisify(connection.query).bind(connection);

//Seleccionar datos para informe
const seleccionar_informe = async function(req, res){
    const ide = req.params.ide;
    const sql = `SELECT * FROM informe WHERE id_uc_inf = ${connection.escape(ide)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}
//Insertar datos para informe
const insertar_informe = async function(req, res){
    const sql = `INSERT INTO informe SET ${connection.escape(req.body)}`;
    const reg = await query(sql);
    res.status(200).send(reg);
}

module.exports = {
    seleccionar_informe,
    insertar_informe
};