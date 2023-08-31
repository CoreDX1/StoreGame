import { component$ } from "@builder.io/qwik";
import { InCancel } from "@qwikest/icons/iconoir";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";

export default component$((prop: { onClose: () => void; game: GameResponse | undefined }) => {
    return (
        <div class="fixed w-full z-10 inset-0 flex items-start justify-center pt-[10%] bg-black bg-opacity-75">
            <div class="bg-white w-[700px] p-8 shadow-md">
                <div class="flex justify-end">
                    <button class="text-gray-500 hover:text-gray-700" onClick$={prop.onClose}>
                        <span class="text-2xl">
                            <InCancel />
                        </span>
                    </button>
                </div>

                <h2 class="text-lg font-semibold mb-4">Editar Juego</h2>
                <form action="" class="flex flex-col">
                    <ul>
                        <li>
                            <label>Nombre: </label>
                            <input
                                type="text"
                                class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                value={prop.game?.title}
                            />
                        </li>
                        <li>
                            <label>Precio: </label>
                            <input
                                type="text"
                                class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                value={prop.game?.price}
                            />
                        </li>
                    </ul>
                </form>
            </div>
        </div>
    );
});
