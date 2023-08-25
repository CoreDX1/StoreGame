import { type BaseResponse } from "~/modules/types/BaseResponse"
import { type Game } from "../Domain/Game"
import { type GameRepository } from "../Domain/GameRepository"

class CreateApiRespository implements GameRepository {
    private GAME_URL: string = "http://localhost:5099/api/Game/List"

    public getAll = async (): Promise<BaseResponse<Game[]>> => {
        const response: Response = await fetch(this.GAME_URL)
        const game = await response.json()
        return game
    }
}

export const ApiGameRepository = new CreateApiRespository()
