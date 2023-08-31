import { type QwikChangeEvent, component$, useStore, $ } from "@builder.io/qwik";
import { InCancel } from "@qwikest/icons/iconoir";
import { type GameResponse } from "~/modules/Game/Domain/GameResponse";

interface State {
    title: string;
    price: number;
    [key: string]: any;
}

interface Props {
    game: GameResponse | undefined;
    onClose: () => void;
}

export default component$<Props>(({ game, onClose }) => {
    const state = useStore<State>({
        price: 0,
        title: "",
    });

    const handleChange = $((event: QwikChangeEvent<HTMLInputElement>) => {
        const { value, name } = event.target;
        state[name] = value;
    });

    const changeForm = $(() => {
        console.log(state);
    });

    return (
        <div class="fixed w-full z-10 inset-0 flex items-start justify-center pt-[10%] bg-black bg-opacity-75">
            <div class="bg-white w-[700px] p-4 shadow-md">
                <div class="flex justify-end">
                    <button class="text-gray-500 hover:text-gray-700" onClick$={onClose}>
                        <span class="text-2xl">
                            <InCancel />
                        </span>
                    </button>
                </div>

                <h2 class="text-lg font-semibold mb-4">Editar Juego</h2>
                <form method="POST" class="flex flex-col" preventdefault:submit onsubmit$={changeForm}>
                    <ul>
                        <li>
                            <label>
                                Nombre:
                                <input
                                    type="nombre"
                                    name="title"
                                    class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                    onChange$={handleChange}
                                    value={game?.title}
                                />
                            </label>
                        </li>
                        <li>
                            <label>
                                Precio:
                                <input
                                    type="text"
                                    name="price"
                                    placeholder="precio"
                                    onChange$={handleChange}
                                    class="w-[300px] p-2 text-black/30 focus:bg-white transition-all duration-300 focus:text-black"
                                    value={game?.price}
                                />
                            </label>
                        </li>
                    </ul>
                    <button type="submit" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
                        Aplicar
                    </button>
                </form>
            </div>
        </div>
    );
});
