export async function getGameSearch(search: string) {
    const url = new URL("http://localhost:5099/api/Game/search");
    url.searchParams.set("query", search);
    const { json } = await fetch(url);
    return await json();
}
