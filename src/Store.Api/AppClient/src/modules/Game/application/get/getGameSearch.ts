import { type Signal } from "@builder.io/qwik";

export async function getGameSearch(url: string, query: Signal<string>, controller: AbortController) {
    const urlA = new URL(url);
    urlA.searchParams.set("query", query.value);

    const resp = await fetch(url, { signal: controller.signal });
    const json = (await resp.json()) as {
        isSuccess: boolean;
        data: Array<{
            title: string;
            website: string;
        }>;
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
