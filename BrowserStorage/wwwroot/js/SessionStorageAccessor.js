export function set(key, value) {
    window.sessionStorage.setItem(key, value);
}

export function get(key) {
    return window.sessionStorage.getItem(key);
}

export function remove(key) {
    window.sessionStorage.removeItem(key);
}

export function clear() {
    window.sessionStorage.clear();
}