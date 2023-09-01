import { component$, useSignal, useTask$, $, useVisibleTask$, useStore } from "@builder.io/qwik";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository";
import { type BaseResponse } from "~/modules/types/BaseResponse";
import { getGameNameOrder, type Order } from "~/modules/Game/application/get/getGameNameOrder";
import EditGameWindow from "~/components/EditGameWindow/EditGameWindow";
import ProductTable from "~/components/ProductTable/ProductTable";
import { HiBars3Solid } from "@qwikest/icons/heroicons";
import Search from "~/components/Search/Search";

export default component$(() => {
    const gameData = useSignal<BaseResponse<GameResponse[]>>();
    const selectGame = useSignal<BaseResponse<GameResponse>>();
    const isEditMode = useSignal<boolean>(false);

    const orderState = useStore<Order>({
        order: "desc",
    });

    const toggleOrder = $(async () => {
        orderState.order = orderState.order === "asc" ? "desc" : "asc";
        gameData.value = await getGameNameOrder(orderState);
    });

    useTask$(async () => {
        gameData.value = await ApiGameRepository.getAll();
    });

    const handleCloseEdit = $(() => {
        isEditMode.value = false;
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

    const handleEditClick = $(async (game: GameResponse) => {
        const response = await ApiGameRepository.getId(game.id);
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
                <Search />
                <ProductTable gameJson={gameData.value} onSelectGame={handleEditClick} order={toggleOrder} />
            </div>
        </div>
    );
});
