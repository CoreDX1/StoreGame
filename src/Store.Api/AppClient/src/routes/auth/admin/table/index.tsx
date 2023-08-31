import { component$, useSignal, useTask$, $, useVisibleTask$ } from "@builder.io/qwik";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository";
import { type BaseResponse } from "~/modules/types/BaseResponse";
import EditGameWindow from "~/components/editGameWindow/editGameWindow";
import ProductTable from "~/components/productTable/productTable";
import { getGameNameOrder } from "~/modules/Game/application/get/getGameNameOrder";

export default component$(() => {
    const gameJson = useSignal<BaseResponse<GameResponse[]>>();

    const selectGame = useSignal<BaseResponse<GameResponse>>();
    const edit = useSignal<boolean>(false);

    const getOrder = $(async () => {
        gameJson.value = await getGameNameOrder();
    });

    useTask$(async () => {
        gameJson.value = await ApiGameRepository.getAll();
    });

    const handleCloseEdit = $(() => {
        edit.value = false;
    });

    useVisibleTask$(() => {
        const handleKeyPress = $(async (event: KeyboardEvent) => {
            if (event.key === "Escape") {
                handleCloseEdit();
            }
        });
        document.addEventListener("keydown", handleKeyPress);
        return () => {
            window.removeEventListener("keydown", handleKeyPress);
        };
    });
    const handleEditClick = $(async (game: GameResponse) => {
        const response = await ApiGameRepository.getId(game.id);
        selectGame.value = response;
        edit.value = true;
    });

    return (
        <div class="col-span-5">
            {edit.value && <EditGameWindow game={selectGame.value?.data} onClose={handleCloseEdit} />}
            <div class="container mx-auto p-4 relative">
                <h2 class="text-xl font-bold mb-4">Tabla de Productos</h2>
                <ProductTable gameJson={gameJson.value} onSelectGame={handleEditClick} order={getOrder} />
            </div>
        </div>
    );
});
