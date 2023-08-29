import { Resource, component$, useResource$, useSignal, useVisibleTask$ } from "@builder.io/qwik";

export default component$(() => {
    const query = useSignal("");
    const nameGames = useResource$<{
        isSuccess: boolean;
        data: Array<{
            title: string;
            website: string;
            price: number;
        }>;
    }>(async ({ track, cleanup }) => {
        track(() => query.value);
        const controller = new AbortController();
        cleanup(() => controller.abort());

        if (query.value.length < 3) {
            return {
                isSuccess: false,
                data: [],
                message: "Ingrese al menos 3 caracteres",
            };
        }

        const url = new URL("http://localhost:5099/api/Game/search");
        url.searchParams.set("query", query.value);
        const resp = await fetch(url, { signal: controller.signal });
        const json = (await resp.json()) as {
            isSuccess: boolean;
            data: Array<{
                title: string;
                website: string;
                price: number;
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
    });
    const IsMenuOpen = useSignal(false);
    const searchContainerRef = useSignal<HTMLInputElement>();
    const formatCurrencyARS = (amount: number) => {
        const formatter = new Intl.NumberFormat("es-AR", {
            style: "currency",
            currency: "ARS",
        });
        return formatter.format(amount);
    };

    useVisibleTask$(() => {
        function handleClickOutside(event: MouseEvent) {
            if (searchContainerRef.value && !searchContainerRef.value.contains(event.target as Node)) {
                IsMenuOpen.value = false;
            }
        }
        document.addEventListener("click", handleClickOutside);
        return () => {
            document.removeEventListener("click", handleClickOutside);
        };
    });

    return (
        <div class="rounded-md w-[500px] max-w-2xl mx-auto relative">
            <div class="flex items-center border rounded-md overflow-hidden" ref={searchContainerRef}>
                <input
                    class="flex-auto bg-transparent  py-2 px-4 focus:outline-none"
                    placeholder="Buscar"
                    onFocus$={() => (IsMenuOpen.value = true)}
                    bind:value={query}
                />
                <button class="bg-primary py-2 px-6 rounded-r-md hover:bg-opacity-80 focus:outline-none">Buscar</button>
            </div>
            <div class="absolute  bg-white w-full  max-w-2xl overflow-y-auto ">
                <Resource
                    value={nameGames}
                    onResolved={(nameGames) => (
                        <div>
                            {IsMenuOpen.value && nameGames.isSuccess && (
                                <ul class="shadow-2xl border">
                                    {nameGames.data.map((game, i) => (
                                        <li
                                            key={i}
                                            class="py-2 text-[#434343CC]  w-auto hover:bg-blue-500 p-3 cursor-pointer bg-white "
                                        >
                                            <div>
                                                <a href={game.website} target="_blank">
                                                    {game.title}
                                                </a>
                                                <p>{formatCurrencyARS(game.price)}</p>
                                            </div>
                                        </li>
                                    ))}
                                </ul>
                            )}
                        </div>
                    )}
                />
            </div>
        </div>
    );
});
