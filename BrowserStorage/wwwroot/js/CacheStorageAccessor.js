

export async function store(url, method, body = "", responseString) {
    const blazorSchoolCache = await openCacheStorageAsync();
    const request = createRequest(url, method, body);
    const response = new Response(responseString);
    await blazorSchoolCache.put(request, response);
}

export async function get(url, method, body = "") {
    const blazorSchoolCache = await openCacheStorageAsync();
    const request = createRequest(url, method, body);
    const response = await blazorSchoolCache.match(request);
    if (response == undefined) {
        return "";
    }
    const result = await response.text();
    return result;

}


export async function remove(url, method, body = "") {
    const blazorSchoolCache = await openCacheStorageAsync();
    const request = createRequest(url, method, body);
    await blazorSchoolCache.delete(request);
}

export async function removeAll() {
    const blazorSchoolCache = await openCacheStorageAsync();
    const requests = await blazorSchoolCache.keys();
    for (var i = 0; i < requests.length; i++) {
        blazorSchoolCache.delete(requests[i]);
    }

}

async function openCacheStorageAsync() {
    return await window.caches.open("BlazorSchooooool");
}


function createRequest(url, method, body = "") {
    const requestInit = {
        method: method
    };

    if (body != "") {
        requestInit.body = body;
    }

    const request = new Request(url, requestInit);
}

