
export function initialize() {
    const myBlazorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    myBlazorIndexedDb.onupgradeneeded = function () {
        const db = myBlazorIndexedDb.result;
        db.createObjectStore("books", { keyPath: "id" });
    }
}

export function set(collectionName, value) {
    const myBlazorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

    myBlazorIndexedDb.onsuccess = function () {
        const transaction = myBlazorIndexedDb.result.transaction(collectionName, "readwrite");
        const collection = transaction.objectStore(collectionName);
        collection.put(value);
    }
}

export async function get(collectionName, id) {
    const request = new Promise((resolve) => {
        const myBlazorIndexedDb = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

        myBlazorIndexedDb.onsuccess = function () {
            const transaction = myBlazorIndexedDb.result.transaction(collectionName, "readonly");
            const collection = transaction.objectStore(collectionName);
            const res = collection.get(id);
            res.onsuccess = function () {
                resolve(res.result)
            }
        }

    });
    const result = await request;
    return request;


}


const DATABASE_NAME = "My Blazor";
const CURRENT_VERSION = 1;