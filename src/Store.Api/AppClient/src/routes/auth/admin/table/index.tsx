import { component$, useSignal, useTask$ } from "@builder.io/qwik";
import { MoEditAlt, MoArrowDown } from "@qwikest/icons/monoicons";
import { InCancel } from "@qwikest/icons/iconoir";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository";
import { type BaseResponse } from "~/modules/types/BaseResponse";

export default component$(() => {
    const gameJson = useSignal<BaseResponse<GameResponse[]>>();

    const selectGame = useSignal<BaseResponse<GameResponse>>();
    const edit = useSignal<boolean>(false);

    useTask$(async () => {
        gameJson.value = await ApiGameRepository.getAll();
    });

    return (
        <div class="col-span-5">
            {edit.value && (
                <div class="fixed w-full z-10 inset-0 flex items-start justify-center pt-[10%] bg-black bg-opacity-75">
                    <div class="bg-white w-[700px] p-8 shadow-md">
                        <div class="flex justify-end">
                            <button
                                class="text-gray-500 hover:text-gray-700"
                                onClick$={() => {
                                    edit.value = false;
                                }}
                            >
                                <span class="text-2xl">
                                    <InCancel />
                                </span>
                            </button>
                        </div>

                        <h2 class="text-lg font-semibold mb-4">Editar Juego</h2>
                        <form action="" class="flex flex-col">
                            <ul>
                                <li>
                                    <label for="">Nombre: </label>
                                    <input
                                        type="text"
                                        class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                        value={selectGame.value?.data.title}
                                    />
                                </li>
                                <li>
                                    <label for="">Precio: </label>
                                    <input
                                        type="text"
                                        class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                        value={selectGame.value?.data.price}
                                    />
                                </li>
                            </ul>
                        </form>
                    </div>
                </div>
            )}
            <div class="container mx-auto p-4 relative">
                <h2 class="text-xl font-bold mb-4">Tabla de Productos</h2>
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
                        {gameJson.value?.data.map((item) => (
                            <tr key={item.id} class="text-start">
                                <td class="py-2 px-4">{item.title}</td>
                                <td class="py-2 px-4">{item.price}</td>
                                <td class="py-2 px-4">Status</td>
                                <td class="py-2 px-4">Total Sale</td>
                                <td class="py-2 px-4">
                                    <button
                                        class="text-2xl"
                                        onClick$={async () => {
                                            const response = await ApiGameRepository.getId(item.id);
                                            selectGame.value = response;
                                            edit.value = true;
                                        }}
                                    >
                                        <MoEditAlt />
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
});
