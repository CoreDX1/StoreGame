import { component$ } from "@builder.io/qwik";
import { MoArrowDown, MoEditAlt } from "@qwikest/icons/monoicons";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { type BaseResponse } from "~/modules/types/BaseResponse";

interface Props {
    gameJson: BaseResponse<GameResponse[]> | undefined;
    onSelectGame: (game: GameResponse) => Promise<void>;
}

export default component$<Props>(({ gameJson, onSelectGame }) => {
    return (
        <table class="min-w-full bg-white">
            <thead class="bg-gray-50">
                <tr>
                    <th class="py-2 px-4">
                        Nombre
                        <button
                            onClick$={() => {
                                console.log("Order by Name");
                            }}
                        >
                            <MoArrowDown />
                        </button>
                    </th>
                    <th class="py-2 px-4">Precio</th>
                    <th class="py-2 px-4">Status</th>
                    <th class="py-2 px-4">Total Sale</th>
                    <th class="py-2 px-4">Accion</th>
                </tr>
            </thead>
            <tbody>
                {gameJson?.data.map((item) => (
                    <tr key={item.id} class="text-start">
                        <td class="py-2 px-4">{item.title}</td>
                        <td class="py-2 px-4">{item.price}</td>
                        <td class="py-2 px-4">Status</td>
                        <td class="py-2 px-4">Total Sale</td>
                        <td class="py-2 px-4">
                            <button class="text-2xl" onClick$={async () => await onSelectGame(item)}>
                                <MoEditAlt />
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
});
