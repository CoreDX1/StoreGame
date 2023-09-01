import { $, type QwikMouseEvent, Resource, component$, useResource$, useSignal } from "@builder.io/qwik";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";

export interface GameResource {
    isSuccess: boolean;
    data: GameResponse[] | undefined;
    message: string;
}

export default component$(() => {
    const query = useSignal("");
    const IsMenuOpen = useSignal(false);
    const searchContainerRef = useSignal<HTMLInputElement>();

    const nameGames = useResource$<GameResource>(async ({ track }) => {
        track(() => query.value);
        const controller = new AbortController();

        if (query.value.length < 3) {
            return {
                isSuccess: false,
                data: [],
                message: "Ingrese al menos 3 caracteres",
            };
        }

        const resp = await fetch(`http://localhost:5099/api/Game/search?query=${query.value}`, {
            signal: controller.signal,
        });

        return await resp.json();
    });

    const formatCurrencyARS = (amount: number) => {
        const formatter = new Intl.NumberFormat("es-AR", {
            style: "currency",
            currency: "ARS",
        });
        return formatter.format(amount);
    };

    const handleDropList = $((event: QwikMouseEvent<HTMLDivElement>) => {
        const id = (event.target as HTMLDivElement).id;
        if (id !== "input-src-qwik") IsMenuOpen.value = false;
    });

    return (
        <div class="rounded-md w-[500px] max-w-2xl mx-auto relative" window:onClick$={handleDropList}>
            <div class="flex items-center border rounded-md overflow-hidden" ref={searchContainerRef}>
                <input
                    class="flex-auto bg-transparent  py-2 px-4 focus:outline-none"
                    placeholder="Buscar"
                    onClick$={() => (IsMenuOpen.value = true)}
                    id="input-src-qwik"
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
                                    {nameGames.data?.map((game, i) => (
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
