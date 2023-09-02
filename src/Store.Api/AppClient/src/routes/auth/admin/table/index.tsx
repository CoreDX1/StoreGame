import { component$, useSignal, useTask$, $, useVisibleTask$, useResource$, useStore } from "@builder.io/qwik";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository";
import { type BaseResponse } from "~/modules/types/BaseResponse";
import EditGameWindow from "~/components/EditGameWindow/EditGameWindow";
import ProductTable from "~/components/ProductTable/ProductTable";
import { HiBars3Solid } from "@qwikest/icons/heroicons";
import { type GameResource } from "~/components/Search/Search";
import { type Order, getGameNameOrder } from "~/modules/Game/application/get/getGameNameOrder";

export default component$(() => {
    const gameData = useSignal<BaseResponse<GameResponse[]>>();
    const selectGame = useSignal<BaseResponse<GameResponse>>();
    const isEditMode = useSignal<boolean>(false);
    const query = useSignal("");

    const orderState = useStore<Order>({
        order: "desc",
    });

    useTask$(async () => {
        gameData.value = await ApiGameRepository.getAll();
    });

    const toggleOrder = $(async () => {
        orderState.order = orderState.order === "asc" ? "desc" : "asc";
        gameData.value = await getGameNameOrder(orderState);
    });

    const handleCloseEdit = $(() => {
        isEditMode.value = false;
    });

    const nameGames = useResource$<GameResource>(async ({ track }) => {
        track(() => query.value);
        const controller = new AbortController();

        if (query.value.length < 3) {
            // await toggleOrder();
            return {
                isSuccess: false,
                data: gameData.value?.data,
                message: "Ingrese al menos 3 caracteres",
            };
        }

        const resp = await fetch(`http://localhost:5099/api/Game/search?query=${query.value}`, {
            signal: controller.signal,
        });
        const json = (await resp.json()) as BaseResponse<GameResponse[]>;
        if (json.data === null!) {
            return {
                isSuccess: false,
                data: [],
                message: "No se encontraron resultados",
            };
        }
        return json;
    });

    useVisibleTask$(() => {
        const handleKeyPress = $(async (event: KeyboardEvent) => {
            event.key === "Escape" && handleCloseEdit();
        });
        document.addEventListener("keydown", handleKeyPress);
        return () => {
            window.removeEventListener("keydown", handleKeyPress);
        };
    });

    const handleEditClick = $(async (id: number) => {
        const response = await ApiGameRepository.getId(id);
        selectGame.value = response;
        isEditMode.value = true;
    });

    return (
        <div class="col-span-5">
            {isEditMode.value && <EditGameWindow game={selectGame.value?.data} onClose={handleCloseEdit} />}
            <div class="container mx-auto p-4 relative">
                <h2 class="text-xl font-bold mb-4 flex items-center">
                    <span class="inline-block mr-2">
                        <HiBars3Solid />
                    </span>
                    Productos
                </h2>
                {/* Filtara juegos */}
                <div class="rounded-md w-[500px] max-w-2xl mx-auto relative" />
                <div class="flex items-center border rounded-md overflow-hidden">
                    <input
                        class="flex-auto bg-transparent  py-2 px-4 focus:outline-none"
                        placeholder="Buscar"
                        id="input-src-qwik"
                        bind:value={query}
                    />
                    <button class="bg-primary py-2 px-6 rounded-r-md hover:bg-opacity-80 focus:outline-none">
                        Buscar
                    </button>
                </div>
                <ProductTable gameJson={nameGames.value} onSelectGame={handleEditClick} order={toggleOrder} />
            </div>
        </div>
    );
});
