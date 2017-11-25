var mongojs = require('mongojs');
var db = mongojs('ng4-events-db', ['events']);

class Event {
    constructor() {

    }
    fetchAllEvents() {
        return new Promise((resolve, reject) => {
            db.events.find((err, docs) => {
                if (err) {
                    reject(err);
                }
                else {
                    resolve(docs);
                }
            });
        });
    }
    fetchSingleEvent(id) {
        return new Promise((resolve, reject) => {
            db.events.findOne({ eventId: Number.parseInt(id) }, (err, doc) => {
                if (err) {
                    reject(err);
                }
                else {
                    resolve(doc);
                }
            });
        })
    }
    insertEvents(event) {
        let promise = new Promise((resolve, reject) => {
            db.events.insert(event, (err) => {
                if (err) {
                    reject(err);
                }
                resolve('Insertion Successfully!');
            });

        });
        return promise;
    }
}
module.exports = new Event();