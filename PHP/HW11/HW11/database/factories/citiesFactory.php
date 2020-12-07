<?php

namespace Database\Factories;

use App\Models\cities;
use Illuminate\Database\Eloquent\Factories\Factory;
use App\Models\countries;

class citiesFactory extends Factory
{
    /**
     * The name of the factory's corresponding model.
     *
     * @var string
     */
    protected $model = cities::class;

    /**
     * Define the model's default state.
     *
     * @return array
     */
    public function definition()
    {
        $all_c = new countries();
        $date = $all_c->inRandomOrder()->first();

        return [
                'city' => $this->faker->city,
                'country_fk' => $date->id,
        ];
    }
}
