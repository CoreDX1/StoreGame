import { component$ } from "@builder.io/qwik"
import { type Game } from "~/modules/Game/Domain/Game"

interface ItemProps {
    data: Game[] | undefined
}

export default component$<ItemProps>((prop) => {
    return (
        <>
            {prop.data?.map((game) => (
                <div key={game.id} class="flex justify-center items-center">
                    <div class="bg-white w-full shadow-md">
                        <img
                            width="616"
                            height="353"
                            src={`/Imagen/${game.imagen}`}
                        ></img>
                        <div class="p-5">
                            <h2 class="text-2xl mb-2 font-normal">
                                {game.title}
                            </h2>
                            <p class="text-2xl text-black font-bold mb-2 text-right">
                                ${game.price}
                            </p>
                            <button
                                class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
                                onClick$={() => {
                                    window.open(game.website)
                                }}
                            >
                                Buy
                            </button>
                        </div>
                    </div>
                </div>
            ))}
        </>
    )
})
