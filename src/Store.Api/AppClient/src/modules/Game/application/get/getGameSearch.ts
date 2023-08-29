import { type Signal } from "@builder.io/qwik";

export async function getGameSearch(url: string, query: Signal<string>, signal: AbortSignal) {
    const urlA = new URL(url);
    urlA.searchParams.set("query", query.value);
    console.log(urlA.toString());

    const resp = await fetch(url, { signal: signal });
    const json = (await resp.json()) as {
        isSuccess: boolean;
        data: Array<{
            title: string;
            website: string;
        }>;
        message: string;
    };
    if (json.data == null!) {
        return {
            isSuccess: false,
            data: [],
            message: "No se encontraron resultados",
        };
    }
    return json;
}
