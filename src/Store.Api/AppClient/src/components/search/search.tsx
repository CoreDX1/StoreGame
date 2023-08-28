import { Resource, component$, useResource$, useSignal } from "@builder.io/qwik";

export default component$(() => {
    const query = useSignal("");
    const nameGames = useResource$<{ title: string; website: string; IsSuccess: boolean }[]>(
        async ({ track, cleanup }) => {
            track(() => query.value);
            const controller = new AbortController();
            cleanup(() => controller.abort());

            if (query.value.length < 3) return [];

            const url = new URL("http://localhost:5099/api/Game/search");
            url.searchParams.set("query", query.value);

            const resp = await fetch(url, { signal: controller.signal });
            const json = (await resp.json()) as {
                IsSuccess: boolean;
                data: { title: string; website: string }[];
                message: string;
            };
            return json.data.map((game) => ({ title: game.title, website: game.website, IsSuccess: json.IsSuccess }));
        }
    );
    return (
        <div class="bg-white rounded-md shadow-md p-4 w-full">
            <div class="flex items-center border border-gray-300 rounded-md overflow-hidden">
                <input
                    class="flex-auto bg-transparent py-2 px-4 focus:outline-none"
                    placeholder="Buscar en Mercado Libre"
                    bind:value={query}
                />
                <button class="bg-primary text-white py-2 px-6 rounded-r-md hover:bg-opacity-80 focus:outline-none">
                    Buscar
                </button>
            </div>
            <div class="mt-4">
                <Resource
                    value={nameGames}
                    onResolved={(nameGames) => (
                        <ul>
                            {nameGames.map((game, i) => (
                                <a
                                    key={i}
                                    onClick$={() => {
                                        window.open(game.website, "_blank");
                                    }}
                                >
                                    <li class="py-2 border-t border-gray-300 hover:bg-blue-500 hover:text-white p-3 cursor-pointer">
                                        {game.title}
                                    </li>
                                </a>
                            ))}
                        </ul>
                    )}
                />
            </div>
        </div>
    );
});
