import { component$, useSignal, useTask$ } from "@builder.io/qwik"
import Product from "~/components/product/product"
import { type Game } from "~/modules/Game/Domain/Game"
import { ApiGameRepository } from "~/modules/Game/infrastructure/ApiGameRepository"
import { type BaseResponse } from "~/modules/types/BaseResponse"

export default component$(() => {
    const responseJson = useSignal<BaseResponse<Game[]>>()

    useTask$(async () => {
        responseJson.value = await ApiGameRepository.getAll()
    })

    return (
        <div class="flex justify-center">
            <div class="w-[900px] grid grid-cols-2 gap-4 pt-5 m-10">
                <Product data={responseJson.value?.data} />
            </div>
        </div>
    )
})
